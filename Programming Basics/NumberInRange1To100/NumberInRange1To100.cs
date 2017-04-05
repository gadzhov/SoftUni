using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInRange1To100
{
    class NumberInRange1To100
    {
        static void Main(string[] args)
        {
            var n = 0;
            while (n < 1 || n > 100)
            {
                Console.WriteLine("Enter a number in the range [1...100]:");
                n = int.Parse(Console.ReadLine());
                if ((n < 1 || n > 100))
                {
                    Console.WriteLine("Ivalid number!");
                }
                else
                {
                    Console.WriteLine(n);
                }
            }
        }
    }
}
