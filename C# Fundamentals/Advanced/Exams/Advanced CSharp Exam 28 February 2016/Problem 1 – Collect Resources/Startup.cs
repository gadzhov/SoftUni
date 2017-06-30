using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1___Collect_Resources
{
    class Startup
    {
        private static readonly string[] allowedMaterials = {"stone", "gold", "wood", "food"};

        static void Main(string[] args)
        {
            var resources = Console.ReadLine()
                .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var numberOfPatherns = int.Parse(Console.ReadLine());
            var tempResources = resources.ToList();
            var collectedPoints = new List<int>();
            for (var i = 0; i < numberOfPatherns; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var start = input[0];
                var step = input[1];
                var currentPoints = 0;
                resources = tempResources.ToArray();

                for (var index = start; index < resources.Length; index += step)
                {
                    if (resources[index] == string.Empty)
                    {
                        break;
                    }

                    var resourceTokens = resources[index].Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                    var material = resourceTokens[0];
                    var value = 1;
                    if (resourceTokens.Length == 2)
                    {
                        value = int.Parse(resourceTokens[1]);
                    }

                    if (allowedMaterials.Contains(material))
                    {
                        currentPoints += value;
                        resources[index] = string.Empty;
                    }
                    // if overflow - reset
                    if (index + step > resources.Length - 1)
                    {
                        index = index - resources.Length;
                    }
                }
                collectedPoints.Add(currentPoints);
            }
            Console.WriteLine(collectedPoints.Max());
        }
    }
}
