using System;
using System.Linq;

namespace _2.Sum_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);

            var numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToList();
            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
