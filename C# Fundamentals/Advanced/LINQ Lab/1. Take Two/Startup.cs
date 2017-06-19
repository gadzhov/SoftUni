using System;
using System.Linq;

namespace _1.Take_Two
{
    class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList();
            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
