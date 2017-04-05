using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());

            if (seconds + 15 > 59)
            {
                minutes++;
                seconds -= 60 - 15;
                if (minutes > 23)
                {
                    minutes = 0;
                }
            }
            else
            {
                seconds += 15;
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
