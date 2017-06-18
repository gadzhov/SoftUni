using System.Linq;

namespace _2.Knights_of_Honor
{
    using System;
    class Startup
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);
            Func<string, string> appendSir = s => $"Sir {s}";
            Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(appendSir)
                .ToList()
                .ForEach(print);
        }
    }
}
