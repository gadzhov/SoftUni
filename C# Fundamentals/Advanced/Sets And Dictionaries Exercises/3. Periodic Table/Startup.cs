using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Periodic_Table
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var result = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var chemicalElements = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var chemicalElement in chemicalElements)
                {
                    result.Add(chemicalElement);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
