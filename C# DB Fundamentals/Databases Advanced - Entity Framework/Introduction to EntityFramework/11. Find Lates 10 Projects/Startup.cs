using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Find_Lates_10_Projects
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10);
            foreach (var p in projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{p.Name} {p.Description} {p.StartDate:M/d/yyyy h:mm:ss tt} {p.EndDate:M/d/yyyy h:mm:ss tt}");
            }
        }
    }
}
