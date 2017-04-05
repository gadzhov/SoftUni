using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastKNumbersSums
{
    class LastKNumbersSums
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] array = new long[n];
            array[0] = 1;
            for (int current = 1; current < n; current++)
            {
                int start = Math.Max(0, current - k);
                int end = current - 1;
                long sum = 0;
                for (int previous = start; previous <= end; previous++)
                {
                    sum += array[previous];
                }
                array[current] = sum;
            }
            for (int i = 0; i < array.Length; i++)
            {
            Console.WriteLine($"{array[i]} ");
            }
        }
    }
}
