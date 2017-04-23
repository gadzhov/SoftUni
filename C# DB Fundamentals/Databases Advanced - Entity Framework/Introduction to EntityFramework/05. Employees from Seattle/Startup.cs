using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Employees_from_Seattle
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees =
                context.Employees.Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.Department.Name} - ${emp.Salary:F2}");
            }
        }
    }
}
