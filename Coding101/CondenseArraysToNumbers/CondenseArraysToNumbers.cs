using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArraysToNumbers
{
    class CondenseArraysToNumbers
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (num.Length > 1)
            {
                int[] sum = new int[num.Length - 1];
                for (int i = 0; i < num.Length - 1; i++)
                {
                    sum[i] = num[i] + num[i + 1];
                }
                num = sum;
                Console.WriteLine(string.Join(" ", num));
            }
        }
    }
}
