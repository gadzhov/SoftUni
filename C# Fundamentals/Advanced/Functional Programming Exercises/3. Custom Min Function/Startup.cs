using System;
using System.Linq;

namespace _3.Custom_Min_Function
{
    class Startup
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallest = nums => nums.Min();
            Console.WriteLine(smallest(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()));
        }
    }
}
