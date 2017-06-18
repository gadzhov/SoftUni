using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Party_Reservation_Filter_Module
{
    class Startup
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var predicates = new Dictionary<string, Func<string, string, bool>>()
            {
                { "Starts with", (name, substring) => name.StartsWith(substring) },
                { "Ends with", (name, substring) => name.EndsWith(substring) },
                { "Length", (name, length) => name.Length.ToString() == length },
                { "Contains", (name, substring) => name.Contains(substring) }
            };

            string input;
            var namesToFilter = new List<string>();

            while ((input = Console.ReadLine()) != "Print")
            {
                var parameters = input
                    .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                var command = parameters[0];
                var filter = parameters[1];
                var filterParameter = parameters[2];

                foreach (var name in names)
                {
                    if (command == "Add filter")
                    {
                        if (predicates[filter](name, filterParameter))
                        {
                            namesToFilter.Add(name);
                        }
                    }
                    else if (command == "Remove filter")
                    {
                        if (predicates[filter](name, filterParameter))
                        {
                            namesToFilter.Remove(name);
                        }
                    }
                }
            }
            foreach (var name in namesToFilter)
            {
                names.Remove(name);
            }
            Console.WriteLine(string.Join(" ", names));
        }
    }
}
