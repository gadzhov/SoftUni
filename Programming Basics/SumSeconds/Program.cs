using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTime = int.Parse(Console.ReadLine());
            var secondTime = int.Parse(Console.ReadLine());
            var thirdTime = int.Parse(Console.ReadLine());
            var seconds = firstTime + secondTime + thirdTime;
            var minutes = 0;

            if (seconds >= 120)
            {
                minutes = 2;
                seconds -= 120;
            }
            else if (seconds >= 60)
            {
                minutes = 1;
                seconds -= 60;
            }
            if (seconds < 10)
            {
                Console.WriteLine("{0}:0{1}", minutes, seconds);
            }
            else
            {
                Console.WriteLine("{0}:{1}", minutes, seconds);
            }

        }
    }
}
