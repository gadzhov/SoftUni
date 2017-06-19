using System;
using System.Linq;

namespace _6.Find_and_Sum_Integers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => int.TryParse(w, out int temp));

            if (text.Any())
            {
                var sum = text
                    .Select(double.Parse)
                    .Sum();
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
