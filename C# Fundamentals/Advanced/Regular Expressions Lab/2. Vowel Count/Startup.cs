using System;
using System.Text.RegularExpressions;

namespace _2.Vowel_Count
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "[AEIOUYaeiouy]";
            var regex = new Regex(pattern);
            var count = regex.Matches(text).Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}
