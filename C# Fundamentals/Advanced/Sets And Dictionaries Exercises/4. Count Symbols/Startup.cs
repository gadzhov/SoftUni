using System;
using System.Collections.Generic;

namespace _4.Count_Symbols
{
    class Startup
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var symbolCounter = new SortedDictionary<char, int>();
            foreach (var ch in text)
            {
                if (!symbolCounter.ContainsKey(ch))
                {
                    symbolCounter.Add(ch, 1);
                    continue;
                }
                symbolCounter[ch]++;
            }
            foreach (var pair in symbolCounter)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
