using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Special_Words
{
    class Startup
    {
        static void Main(string[] args)
        {
            var specialWords = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine().Split(new [] {' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var result = new Dictionary<string, int>();

            foreach (var item in specialWords)
            {
                result[item] = 0;
            }

            foreach (var word in text)
            {
                if (result.ContainsKey(word))
                {
                    result[word]++;
                }
            }
            
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
