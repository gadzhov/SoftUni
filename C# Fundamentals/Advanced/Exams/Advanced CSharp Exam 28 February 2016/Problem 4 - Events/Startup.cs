using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_4___Events
{
    class Startup
    {
        static void Main(string[] args)
        {
            var numberOfEvents = int.Parse(Console.ReadLine());
            const string pattern = "(?<=^)#(?<name>[A-Za-z]+):(?=\\s|@)\\s*@(?<town>[A-Za-z]+)\\s*(?<hours>[0-9]+):(?<minutes>[0-9]+)\\b";
            var regex = new Regex(pattern);
            var events = new Dictionary<string, Dictionary<string, List<DateTime>>>();

            for (int i = 0; i < numberOfEvents; i++)
            {
                var input = Console.ReadLine();
                var match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }
                var name = match.Groups["name"].Value;
                var town = match.Groups["town"].Value;
                var hours = int.Parse(match.Groups["hours"].Value);
                var minutes = int.Parse(match.Groups["minutes"].Value);

                if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                {
                    if (!events.ContainsKey(town))
                    {
                        events.Add(town, new Dictionary<string, List<DateTime>>());
                        events[town].Add(name, new List<DateTime>());
                        events[town][name].Add(new DateTime(1, 1, 1, hours, minutes, 0));
                    }
                    else
                    {
                        if (!events[town].ContainsKey(name))
                        {
                            events[town].Add(name, new List<DateTime>());
                            events[town][name].Add(new DateTime(1, 1, 1, hours, minutes, 0));
                        }
                        else
                        {
                            events[town][name].Add(new DateTime(1, 1, 1, hours, minutes, 0));
                        }
                    }
                }
            }
            var desiredLocations = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var location in desiredLocations.OrderBy(l => l))
            {
                if (events.ContainsKey(location))
                {
                    Console.WriteLine($"{location}:");
                    var index = 1;
                    foreach (var info in events[location].OrderBy(p => p.Key))
                    {
                        Console.WriteLine($"{index}. {info.Key} -> {string.Join(", ", info.Value.OrderBy(t => t).Select(d => d.ToString("HH:mm")))}");
                        index++;
                    }
                }
            }
        }
    }
}
