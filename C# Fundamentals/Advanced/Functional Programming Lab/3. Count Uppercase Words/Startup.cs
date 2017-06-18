using System;
using System.Linq;

namespace _3.Count_Uppercase_Words
{
    class Startup
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
