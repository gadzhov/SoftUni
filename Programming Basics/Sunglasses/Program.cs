using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(
                new string('*', n * 2) +
                new string(' ', n) +
                new string('*', n * 2));
            for (int row = 1; row <= n - 2; row++)
            {
                Console.Write(
                    "*" +
                    new string('/', n * 2 - 2) +
                    "*");

                if (n % 2 == 0)
                {
                    if (row == n / 2 - 1)
                    {
                        Console.Write(new string('|', n));
                    }
                    else
                    {
                        Console.Write(new string(' ', n));
                    }
                }
                else
                {
                    if (row == n / 2)
                    {
                        Console.Write(new string('|', n));
                    }
                    else
                    {
                        Console.Write(new string(' ', n));
                    }
                }

                Console.WriteLine("*" +
                new string('/', n * 2 - 2) +
                "*");
            }
            Console.WriteLine(
               new string('*', n * 2) +
               new string(' ', n) +
               new string('*', n * 2));
        }
    }
}
