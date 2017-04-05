using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Employees_with_Salary_Over
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var richman = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName).ToList();
            foreach (var emp in richman)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
