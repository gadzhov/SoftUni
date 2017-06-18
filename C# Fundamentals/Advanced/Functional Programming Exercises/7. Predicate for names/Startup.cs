using System;
using System.Linq;

namespace _7.Predicate_for_names
{
    class Startup
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            Predicate<string> lengthPredicate = s => s.Length <= num;
            Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => lengthPredicate(w))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
