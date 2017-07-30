using System;
using System.Collections.Generic;
using Problem_5.Comparing_Objects.Models;

namespace Problem_5.Comparing_Objects
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            var people = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = cmdArgs[0];
                var age = int.Parse(cmdArgs[1]);
                var town = cmdArgs[2];

                people.Add(new Person(name, age, town));
            }
            var targetIndex = int.Parse(Console.ReadLine());
            Person targetPerson = null;
            try
            {
                targetPerson = people[targetIndex];
            }
            catch
            {
                // ignored
            }

            var equalPeople = 0;

            foreach (var p in people)
            {
                if (targetPerson != null && targetPerson.CompareTo(p) == 0)
                {
                    equalPeople++;
                }
            }

            Console.WriteLine((equalPeople != 0 ? $"{equalPeople} {people.Count - equalPeople} {people.Count}" : "No matches"));
        }
    }
}
