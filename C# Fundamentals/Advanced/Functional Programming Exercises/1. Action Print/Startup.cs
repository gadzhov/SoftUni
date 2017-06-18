using System;
using System.Linq;

namespace _1.Action_Print
{
    class Startup
    {
        static void Main(string[] args)
        {
            Action<string> print = w => Console.WriteLine(w);

            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
