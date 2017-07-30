using System;
using System.Collections.Generic;
using Problem_7.Equality_Logic.Models;

namespace Problem_7.Equality_Logic
{
    public class Startup
    {
        public static void Main()
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var currentPerson = new Person(inputArgs[0], int.Parse(inputArgs[1]));

                sortedSet.Add(currentPerson);
                hashSet.Add(currentPerson);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
