using System;
using System.Text.RegularExpressions;

namespace _8.Extract_Quotations
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "(\"|\')(.+?)\\1";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2].Value);
            }
        }
    }
}
