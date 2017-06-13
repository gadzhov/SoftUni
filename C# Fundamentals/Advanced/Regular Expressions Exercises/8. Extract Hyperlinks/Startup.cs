using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _8.Extract_Hyperlinks
{
    class Startup
    {
        static void Main(string[] args)
        {
            // input
            string inputLine;
            var sb = new StringBuilder();
            while ((inputLine = Console.ReadLine()) != "END")
            {
                sb.Append(inputLine);
            }
            var text = sb.ToString();

            // logic
            const string pattern = @"<a\s+(?:[^>]+\s+)?href\s*=\s*(?:'([^']*)'|""([^""]*)""|([^\s>]+))[^>]*>";
            var users = new Regex(pattern);
            var matches = users.Matches(text);

            // print
            foreach (Match hyperlink in matches)
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (hyperlink.Groups[i].Length > 0)
                    {
                        Console.WriteLine(hyperlink.Groups[i]);
                    }
                }
            }
        }
    }
}
