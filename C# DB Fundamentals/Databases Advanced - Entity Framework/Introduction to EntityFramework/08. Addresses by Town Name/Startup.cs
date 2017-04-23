using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Addresses_by_Town_Name
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var addresses = context.Addresses.OrderByDescending(e => e.Employees.Count).ThenBy(t => t.Town.Name).Take(10).ToList();
            addresses.ForEach(e => Console.WriteLine($"{e.AddressText}, {e.Town.Name} - {e.Employees.Count} employees"));
        }
    }
}
