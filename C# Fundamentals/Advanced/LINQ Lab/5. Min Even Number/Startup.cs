using System;
using System.Linq;

namespace _5.Min_Even_Number
{
    class Startup
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n % 2 == 0);

            if (result.Count() != 0)
            {
                Console.WriteLine($"{result.Min():F2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
