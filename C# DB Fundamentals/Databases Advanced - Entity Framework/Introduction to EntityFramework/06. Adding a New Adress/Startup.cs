using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Adding_a_New_Adress
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };
            var employee = context.Employees.Where(e => e.LastName == "Nakov").ToList();
            foreach (var emp in employee)
            {
                emp.Address = address;
            }
            employee = context.Employees.OrderByDescending(e => e.AddressID).Take(10).ToList();
            foreach (var emp in employee)
            {
                Console.WriteLine(emp.Address.AddressText);
            }
            context.SaveChanges();
        }
    }
}
