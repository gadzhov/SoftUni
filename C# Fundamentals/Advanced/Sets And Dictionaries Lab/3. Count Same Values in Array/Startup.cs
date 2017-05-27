using System.Collections.Generic;

namespace _3.Count_Same_Values_in_Array
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var inputArray = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            var dict = new SortedDictionary<double, int>();

            foreach (var number in inputArray)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 1);
                }
                else
                {
                    dict[number]++;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
