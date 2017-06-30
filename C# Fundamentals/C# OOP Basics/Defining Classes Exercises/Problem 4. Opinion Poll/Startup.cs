using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4.Opinion_Poll
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var inputTokens = Console.ReadLine().Split(' ');
                var member = new Person()
                {
                    Name = inputTokens[0],
                    Age = int.Parse(inputTokens[1])
                };
                people.Add(member);
            }
            people.Where(m => m.Age > 30)
                .OrderBy(m => m.Name)
                .ToList()
                .ForEach(m => Console.WriteLine($"{m.Name} - {m.Age}"));
        }
    }
}
