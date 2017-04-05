using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            var leapNormal = Console.ReadLine();
            var holydays = int.Parse(Console.ReadLine());
            var weekendsAtHome = int.Parse(Console.ReadLine());
            var suturdaysGamesInSofia = (48.0 - weekendsAtHome) * (3.0 / 4.0);
            var gamesAtHome = weekendsAtHome;
            var gamesAtSofiaInHolydays = holydays * (2.0 / 3.0);
            var gamesTotal = suturdaysGamesInSofia + gamesAtHome + gamesAtSofiaInHolydays;
            if (leapNormal == "leap")
            {
                var leapBonus = gamesTotal * 0.15;
                gamesTotal += leapBonus;
            }
            Console.WriteLine(Math.Floor(gamesTotal));
        }
    }
}
