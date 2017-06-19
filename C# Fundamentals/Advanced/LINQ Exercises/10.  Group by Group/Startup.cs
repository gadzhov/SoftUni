using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Group_by_Group
{
    class Startup
    {
        private class Person
        {
            public string Name { get; set; }
            public int Group { get; set; }
        }
        static void Main(string[] args)
        {
            string input;
            var persons = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                var personInfo = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                persons.Add(new Person()
                {
                    Name = $"{personInfo[0]} {personInfo[1]}",
                    Group = int.Parse(personInfo[2])
                });
            }

            var grouped = persons
                .GroupBy(p => p.Group)
                .OrderBy(p => p.Key)
                .ToList();

            foreach (var group in grouped)
            {
                Console.Write(group.Key + " - ");
                var sb = new StringBuilder();
                foreach (var person in group)
                {
                    sb.Append(person.Name).Append(", ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }
        }
    }
}
