using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var oddSum = 0.0;
            var oddMin = double.MaxValue;
            var oddMax = double.MinValue;
            var evenSum = 0.0;
            var evenMin = double.MaxValue;
            var evenMax = double.MinValue;
            for (int i = 1; i <= n; i++)
            {
                var num = double.Parse(Console.ReadLine());
                if (n == 1)
                {
                    oddSum = num;
                    oddMin = num;
                    oddMax = num;
                }
                else if (i % 2 != 0)
                {
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    oddSum += num;
                }
                else
                {
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    evenSum += num;
                }
            }
            if (n == 0)
            {
                Console.WriteLine("OddSum={0}, \nOddMin={1}, \nOddMax={2}, \nEvenSum={3}, \nEvenMin={4}, \nEvenMax={5}", 0, "No", "No", 0, "No", "No");
            }
            else if (evenMin == double.MaxValue)
            {
                Console.WriteLine("OddSum={0}, \nOddMin={1}, \nOddMax={2}, \nEvenSum={3}, \nEvenMin={4}, \nEvenMax={5}", oddSum, oddMin, oddMax, evenSum, "No", "No");
            }
            else if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddSum={0}, \nOddMin={1}, \nOddMax={2}, \nEvenSum={3}, \nEvenMin={4}, \nEvenMax={5}", oddSum, oddMin, oddMax, evenSum, "No", "No");
            }
            else
            {
                Console.WriteLine("OddSum={0}, \nOddMin={1}, \nOddMax={2}, \nEvenSum={3}, \nEvenMin={4}, \nEvenMax={5}", oddSum, oddMin, oddMax, evenSum, evenMin, evenMax);
            }
        }
    }
}
