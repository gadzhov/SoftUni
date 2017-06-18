using System;
using System.Linq;

namespace _6.Reverse_and_exclude
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Read a colection of numbers
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
            var n = int.Parse(Console.ReadLine());

            Predicate<int> divisiblePredicate = num => num % n != 0;

            Console.WriteLine(string.Join(" ", numbers.Reverse().Where(num => divisiblePredicate(num))));
        }
    }
}
