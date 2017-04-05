using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExactSumOfRealNumbers
{
    class ExactSumOfRealNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal num = 0;
            for (int i = 0; i < n; i++)
            {
                num += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(num);
        }
    }
}
