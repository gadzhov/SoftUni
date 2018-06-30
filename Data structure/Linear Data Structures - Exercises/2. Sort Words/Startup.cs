using System;
using System.Linq;

namespace _2.Sort_Words
{
    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.Write(x + " "));
        }
    }
}
