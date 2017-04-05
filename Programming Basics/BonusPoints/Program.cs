using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = double.Parse(Console.ReadLine());
            var bonusPoints = 0.0;
            var extraPoints = 0.0;
            if (points <= 100)
            {
                bonusPoints = 5;
            }
            else if (points > 100 && points < 1000)
            {
                bonusPoints = points * 0.2;
            }
            else if (points > 1000)
            {
                bonusPoints = points * 0.1;
            }
            if (points % 2 == 0)
            {
                extraPoints = 1;
            }
            else if (points % 5 == 0)
            {
                extraPoints = 2;
            }
            Console.WriteLine(bonusPoints + extraPoints);
            Console.WriteLine(points + bonusPoints + extraPoints);
        }
    }
}
