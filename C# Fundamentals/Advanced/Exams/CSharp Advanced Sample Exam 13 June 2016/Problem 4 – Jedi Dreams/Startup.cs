using System;
using System.Text.RegularExpressions;

namespace Problem_4___Jedi_Dreams
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                foreach (Match match in Regex.Matches(input, "\\bstatic\\s[a-z]+\\s(?<method>[A-Z][A-Za-z]*)"))
                {
                    var method = match.Groups["method"].Value;
                }
            }
        }
    }
}
