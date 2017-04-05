using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int position = 0;
            while (position < nums.Count - 1)
            {
                if (nums[position] == nums[position + 1])
                {
                    nums.RemoveAt(position);
                    nums[position] = 2 * nums[position];
                    if (position > 0)
                    {
                        position--;
                    }
                }
                else
                {
                    position++;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
