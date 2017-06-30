using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Cubic_Assault
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            var regions = new SortedDictionary<string, SortedDictionary<string, long>>();

            while ((input = Console.ReadLine()) != "Count em all")
            {
                var inputTokens = input.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var regionName = inputTokens[0].Trim();
                var meteorType = inputTokens[1].Trim();
                var count = long.Parse(inputTokens[2].Trim());

                if (!regions.ContainsKey(regionName))
                {
                    regions.Add(regionName, new SortedDictionary<string, long>());
                    regions[regionName].Add("Green", 0);
                    regions[regionName].Add("Red", 0);
                    regions[regionName].Add("Black", 0);
                    regions[regionName][meteorType] = count;
                    if (regions[regionName][meteorType] >= 1000000)
                    {
                        regions = Update(regions, regionName, meteorType);
                    }
                }
                else
                {
                    regions[regionName][meteorType] += count;
                    if (regions[regionName][meteorType] >= 1000000)
                    {
                        regions = Update(regions, regionName, meteorType);
                    }
                }
            }
            foreach (var region in regions.OrderByDescending(rg => rg.Value["Black"]).ThenBy(rg => rg.Key.Length).ThenBy(rg => rg.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var regionInfo in region.Value.OrderByDescending(ri => ri.Value).ThenBy(ri => ri.Key))
                {
                    Console.WriteLine($"-> {regionInfo.Key} : {regionInfo.Value}");
                }
            }
        }

        private static SortedDictionary<string, SortedDictionary<string, long>> Update(
            SortedDictionary<string, SortedDictionary<string, long>> regions,string regionName, string meteorType)
        {
            switch (meteorType)
            {
                case "Green":
                    regions[regionName]["Red"] += regions[regionName][meteorType] / 1000000;
                    regions[regionName][meteorType] %= 1000000;
                    break;
                case "Red":
                    regions[regionName]["Black"] += regions[regionName][meteorType] / 1000000;
                    regions[regionName][meteorType] %= 1000000;
                    break;
            }
            if (regions[regionName]["Red"] >= 1000000)
            {
                regions = Update(regions, regionName, "Red");
            }

            return regions;
        }
    }
}
