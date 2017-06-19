using System;
using System.Linq;

namespace _2.Upper_Strings
{
    class Startup
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToUpper())
                .ToList()
                .ForEach(w => Console.Write($"{w} "));
        }
    }
}
