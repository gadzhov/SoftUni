using System;
using System.Collections.Generic;
using Problem_6.Strategy_Pattern.Models;
using Problem_6.Strategy_Pattern.Models.Comparators;

namespace Problem_6.Strategy_Pattern
{
    public class Startup
    {
        public static void Main()
        {
            var nSet = new SortedSet<Person>(new NameComparator());
            var aSet = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(inputArgs[0], int.Parse(inputArgs[1]));

                nSet.Add(person);
                aSet.Add(person);
            }

            foreach (var person in nSet)
            {
                Console.WriteLine(person);
            }
            foreach (var person in aSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}
