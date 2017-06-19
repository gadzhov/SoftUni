using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Map_Districts
{
    class Startup
    {
        static void Main(string[] args)
        {
            var towns = new Dictionary<string, List<long>>();
            var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in elements)
            {
                var info = element.Split(':');
                var town = info[0];
                var population = long.Parse(info[1]);
                if (!towns.ContainsKey(town))
                {
                    towns.Add(town, new List<long>());
                }
                towns[town].Add(population);
            }
            var bound = long.Parse(Console.ReadLine());

            towns = towns
                .Where(t => t.Value.Sum() > bound)
                .OrderByDescending(t => t.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var town in towns)
            {
                var districts = town.Value
                    .OrderByDescending(x => x)
                    .Take(5);
                Console.WriteLine($"{town.Key}: {string.Join(" ", districts)}");
            }

        }
    }
}
