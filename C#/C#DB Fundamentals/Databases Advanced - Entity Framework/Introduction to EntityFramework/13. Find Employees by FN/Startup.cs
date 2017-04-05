using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Find_Employees_by_FN
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees.Where(e => e.FirstName.StartsWith("Sa"));
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
            }
        }
    }
}
