using System;
using System.Text.RegularExpressions;

namespace _6.Sentence_Extractor
{
    class Startup
    {
        static void Main(string[] args)
        {
            var keyWord = Console.ReadLine();
            var text = Console.ReadLine();
            var pattern = "[^.!?]+(?=[!.?])[.!?]";
            var regex = new Regex(pattern);

            foreach (Match match in regex.Matches(text))
            {
                if (IsContainsKeyWord(keyWord, match))
                {
                    Console.WriteLine(match);
                }
            }
        }

        private static bool IsContainsKeyWord(string keyWord, Match match)
        {
            var pattern = $"\\s{keyWord}\\s";
            var regex = new Regex(pattern);
            return regex.Match(match.ToString()).Success;
        }
    }
}
