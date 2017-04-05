using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersFrom1ToNWithStep3
{
    class NumbersFrom1ToNWithStep3
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i+= 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
