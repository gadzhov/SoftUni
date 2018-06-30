using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Count_of_Occurrences
{
    public class Startup
    {
        public static void Main()
        {
            var collection = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var result = new Dictionary<int, int>();

            foreach (var item in collection)
            {
                if (!result.ContainsKey(item))
                {
                    result.Add(item, 1);
                }
                else
                {
                    result[item]++;
                }
            }

            foreach (var kv in result.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kv.Key} -> {kv.Value} times");
            }
        }
    }
}
