using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            /*
             create proc usp_GetProjectsByEmployee @firstName varchar(50), @lastName varchar(50)
             as
             begin
                select p.Name, p.Description, p.StartDate from Employees as e
                inner join EmployeesProjects as ep
                on ep.EmployeeID = e.EmployeeID
                inner join Projects as p
                on p.ProjectID = ep.ProjectID
                where e.FirstName = @firstName and e.LastName = @lastName
             end
             */
            //CallStoredProcedure(context);
            EmployeesMaximumSalaries(context);
        }
        //18.
        private static void EmployeesMaximumSalaries(SoftUniContext context)
        {
            context.Departments.Select(d => new
            {
                d.Name,
                MaxSalary = d.Employees.Max(e => e.Salary)
            })
                .Where(arg => arg.MaxSalary < 30000 || arg.MaxSalary > 70000)
                .ToList()
                .ForEach(d => Console.WriteLine($"{d.Name} - {d.MaxSalary}"));
        }

        //17.
        private static void CallStoredProcedure(SoftUniContext context)
        {
            var inputText = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstName = new SqlParameter("@firstName", SqlDbType.VarChar) { Value = inputText[0] };
            var lastName = new SqlParameter("@lastName", SqlDbType.VarChar) { Value = inputText[1] };
            var projects = context.Database.SqlQuery<GetProjectByEmployee>("usp_GetProjectsByEmployee @firstName, @lastName", firstName, lastName);
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description}, {project.StartDate}");
            }
        }
    }
}
