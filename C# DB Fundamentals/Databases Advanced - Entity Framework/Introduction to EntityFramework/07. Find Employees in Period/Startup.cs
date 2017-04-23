using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Find_Employees_in_Period
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees =
                context.Employees.Where(
                    e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0).Take(30);
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Employee1.FirstName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate:M/d/yyyy h:mm:ss tt} {p.EndDate:M/d/yyyy h:mm:ss tt}");
                }
            }
        }
    }
}
