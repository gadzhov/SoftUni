using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMethod
{
    class MaxMethod
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = 0;
            a = GetMax(a, b, max);
            b = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(a, b, max));
        }
        static int GetMax(int a, int b, int max)
        {
            max = Math.Max(a, b);
            return max;
        }
    }
}
