using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_Full_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var employee = context.Employees.OrderBy(e => e.EmployeeID).ToList();
            foreach (var emp in employee)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary}");
            }
        }
    }
}
