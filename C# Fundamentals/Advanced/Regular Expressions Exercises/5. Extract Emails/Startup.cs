using System;
using System.Text.RegularExpressions;

namespace _5.Extract_Emails
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "(?<=\\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\\-?[a-z]+\\.)+[a-z]+\\-?[a-z]+)\\b";
            var regex = new Regex(pattern);

            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine(match);
            }
        }
    }
}
