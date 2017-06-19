using System;
using System.Linq;

namespace _3.First_Name
{
    class Startup
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var ch = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower());

            var result = names
                .Where(n => ch.Any(n.ToLower().StartsWith))
                .OrderBy(n => n)
                .Take(1)
                .ToList();

            if (result.Count != 0)
            {
                Console.WriteLine(result[0]);
                return;
            }
            Console.WriteLine("No match");
        }
    }
}
