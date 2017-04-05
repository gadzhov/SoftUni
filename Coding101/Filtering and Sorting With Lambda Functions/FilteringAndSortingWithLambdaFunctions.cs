using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering_and_Sorting_With_Lambda_Functions
{
    class FilteringAndSortingWithLambdaFunctions
    {
        static void Main(string[] args)
        {
            int[] nums = { 11, 99, 33, 55, 77, 44, 66, 22, 88 };
            var smallNums = nums.Where(x => x < 50);
            Console.WriteLine("Nums < 50: "  + string.Join(" ",smallNums));
            Console.WriteLine("Odd numbers count: " + nums.Where(x => x % 2 == 1).Count());
            Console.WriteLine("Smallesst 3 nums: " + string.Join(" ",nums.OrderBy(x => x).Take(3)));
            Console.WriteLine("First 5 nums * 2: " + string.Join(" ",nums.Select(x => x * 2).Take(5)));
        }
    }
}
