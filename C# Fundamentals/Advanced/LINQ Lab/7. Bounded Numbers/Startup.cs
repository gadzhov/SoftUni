using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace _7.Bounded_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var boundTokens = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var lowerBound = Math.Min(boundTokens[0], boundTokens[1]);
            var upperBound = Math.Max(boundTokens[0], boundTokens[1]);

            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= lowerBound && n <= upperBound)
                .ToList();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
