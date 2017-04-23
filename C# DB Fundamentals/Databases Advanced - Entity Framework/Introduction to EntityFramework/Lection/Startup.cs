using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection
{
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            Employee employee = context.Employees.First();
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
