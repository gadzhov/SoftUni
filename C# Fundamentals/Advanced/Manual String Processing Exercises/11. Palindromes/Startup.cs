using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Palindromes
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new[] {' ', ',', '.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new SortedSet<string>();

            foreach (var word in text)
            {
                if (word.SequenceEqual(word.Reverse()))
                {
                    palindromes.Add(word);
                }
            }

            Console.WriteLine("[" + string.Join(", ", palindromes) + "]");
        }
    }
}
