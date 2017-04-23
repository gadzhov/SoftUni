using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Increase_Salary
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var departments =
                context.Departments.Where(
                    d =>
                        d.Name == "Engineering" || d.Name == "Tool Design" || d.Name == "Marketing" ||
                        d.Name == "Information Services");
            foreach (var d in departments)
            {
                foreach (var e in d.Employees)
                {
                    e.Salary *= 1.12m;
                    Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary})");
                }
            }
            context.SaveChanges();
        }
    }
}
