using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestThreNumbers
{
    class LargestThreNumbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderBy(x => -x)
                .Take(3)
                .ToList();
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
