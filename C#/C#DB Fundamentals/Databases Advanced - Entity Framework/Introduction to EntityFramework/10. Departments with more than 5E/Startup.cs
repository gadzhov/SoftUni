using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Departments_with_more_than_5E
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var departments =
                context.Departments.Where(d => d.Employees.Count > 5).OrderBy(e => e.Employees.Count).ToList();
            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Name} {d.Employee.FirstName}");
                foreach (var e in d.Employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
                }
            }
        }
    }
}
