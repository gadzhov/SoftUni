using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAReceipt
{
    class PrintAReceipt
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray().ToArray();
            double sum = 0;
            Console.WriteLine($"/{new string('-', 22)}\\");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"|{numbers[i],21:f2} |");
                sum += numbers[i];
            }
            Console.WriteLine($"|{new string('-', 22)}|");
            Console.WriteLine($"| Total:{sum,14:f2} |");
            Console.WriteLine($"\\{new string('-', 22)}/");
        }
    }
}
