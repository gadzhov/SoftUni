using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleSum
{
    class TripleSum
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = true;
            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int b = nums[j];
                    int sum = a + b;
                    if (nums.Contains(sum))
                    {
                        Console.WriteLine($"{a} + {b} == {sum}");
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("No");
            }
        }
    }
}
