using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElement
{
    class MaxSequenceOfEqualElement
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            nums.Reverse();
            int[] counts = new int[nums.Max() + 1];
            int equal = 1;
            int temp = 1;
            bool isNegative = false;
            for (int i = 0; i < nums.Count; i++)
            {
                int num = nums[i];
                if (num < 0)
                {
                    num *= -1;
                    isNegative = true;
                }
                counts[num]++;
                temp = counts.Max();
                if (counts[num] == temp)
                {
                    equal = num;
                }
            }
            if (isNegative == true)
            {
                for (int i = 0; i < counts.Max(); i++)
                {
                Console.WriteLine($"-{equal} ");
                }
            }
            else
            {
                if (counts.Max() == 1)
                {
                    Console.WriteLine($"{nums.Last()}");
                }
                else
                {
                    for (int i = 0; i < counts.Max(); i++)
                    {
                        Console.Write($"{equal} ");
                    }
                }
            }
        }

    }
}

