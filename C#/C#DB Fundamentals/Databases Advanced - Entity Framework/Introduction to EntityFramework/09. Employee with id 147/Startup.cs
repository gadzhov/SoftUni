using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Employee_with_id_147
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var employee = context.Employees.Where(e => e.EmployeeID == 147).ToList();
            employee.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}"));
            foreach (var proj in employee)
            {
                foreach (var p in proj.Projects.OrderBy(n => n.Name))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }
    }
}
