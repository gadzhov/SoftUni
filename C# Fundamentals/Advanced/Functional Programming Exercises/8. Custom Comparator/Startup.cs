using System;
using System.Linq;

namespace _8.Custom_Comparator
{
    class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Sort array with custom comparison method
            Array.Sort(numbers, (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                if (x > y)
                {
                    return 1;
                }
                if (x < y)
                {
                    return -1;
                }
                return 0;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
