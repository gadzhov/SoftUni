using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Find_Evens_or_Odds
{
    class Startup
    {
        static void Main(string[] args)
        {
            // obtain list size
            var listSize = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var min = listSize.Min();
            var max = listSize.Max();

            // obtain option
            var option = Console.ReadLine();

            var list = new List<int>();
            // populate list
            for (var i = min; i <= max; i++)
            {
                list.Add(i);
            }

            // declare predicate
            Predicate<int> even =  n =>  n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;
                
            // output processing
            if (option.ToLower() == "even")
            {
                Console.WriteLine(string.Join(" ", list.FindAll(even)));
            }
            else if (option.ToLower() == "odd")
            {
                Console.WriteLine(string.Join(" ", list.FindAll(odd)));   
            }
        }
    }
}
