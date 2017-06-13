using System;
using System.Text.RegularExpressions;

namespace _4.Extract_Integer_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "\\d+";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
