using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Logs_Aggregator
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var logsAggregator = new SortedDictionary<string, SortedDictionary<string, int>>();
            
            for (int i = 0; i < n; i++)
            {
                var inputArray = Console.ReadLine()
                    .Split(' ');
                var ip = inputArray[0];
                var name = inputArray[1];
                var duration = int.Parse(inputArray[2]);

                if (!logsAggregator.ContainsKey(name))
                {
                    logsAggregator.Add(name, new SortedDictionary<string, int>());
                    logsAggregator[name].Add(ip, duration);
                    continue;
                }
                if (!logsAggregator[name].ContainsKey(ip))
                {
                    logsAggregator[name].Add(ip, duration);
                }
                else
                {
                    logsAggregator[name][ip] += duration;
                }
            }

            foreach (var logUser in logsAggregator)
            {
                Console.Write($"{logUser.Key}: ");
                Console.Write($"{logUser.Value.Values.Sum()} ");
                Console.Write("[" + string.Join(", ", logUser.Value.Keys) + "]");
                Console.WriteLine();
            }
        }
    }
}
