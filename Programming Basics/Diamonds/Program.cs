using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamonds
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 1;
            var mid = 1;
            var side = (n - 2 * stars - mid) / 2;
            if (n % 2 == 0)
            {
                mid++;
                stars++;
            }
            Console.WriteLine(new string('-', (n - stars) / 2) + new string('*', stars) + new string('-', (n - stars) / 2));
            for (int row = 0; row < (n - 1) / 2; row++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', side), "*", new string('-', mid));
                side -= 1;
                mid += 2;
            }
            side += 1;
            mid -= 2;
            for (int row = (n - 1) / 2 - 1; row > 0; row--)
            {
                side += 1;
                mid -= 2;
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', side), "*", new string('-', mid));
            }
            if (n > 2)
            {
                Console.WriteLine(new string('-', (n - stars) / 2) + new string('*', stars) + new string('-', (n - stars) / 2));
            }
        }
    }
}
