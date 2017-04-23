using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.First_Letter
{
    class Startup
    {
        static void Main()
        {
            var context = new GringottsEntity();
            var wizzards =
                context.WizzardDeposits
                .Where(d => d.DepositGroup == "Troll Chest")
                .Select(wd => wd.FirstName)
                .ToList()
                .Select(fn => fn[0])
                .Distinct()
                .OrderBy(c => c)
                .ToList();
            wizzards.ForEach(Console.WriteLine);
        }
    }
}
