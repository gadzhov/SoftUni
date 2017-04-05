using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumArrays
{
    class SumArrays
    {
        static void Main(string[] args)
        {
            int[] numOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = Math.Max(numOne.Length, numTwo.Length);
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = numOne[i % numOne.Length] + numTwo[i % numTwo.Length];
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
