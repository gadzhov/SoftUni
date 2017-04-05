using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 0;
            var bg = 0;
            if (n % 2 == 0)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
            if (stars == 2)
            {
                bg = (n - 2) / 2;
            }
            else
            {
                bg = (n - 1) / 2;
            }
            for (int row = 0; row < (n + 1) / 2; row++)
            {

                Console.WriteLine(new string('-', bg) + new string('*', stars) + new string('-', bg));
                stars += 2;
                bg -= 1;
            }
            for (int row = 0; row < n - ((n + 1) / 2); row++)
            {
                Console.WriteLine("|" + new string('*', n - 2) + "|");
            }

        }
    }
}
