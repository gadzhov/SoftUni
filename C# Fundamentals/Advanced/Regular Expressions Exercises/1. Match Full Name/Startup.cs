using System;
using System.Text.RegularExpressions;

namespace _1.Match_Full_Name
{
    class Startup
    {
        static void Main(string[] args)
        {
            const string pattern = "\\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\\b";
            var regex = new Regex(pattern);
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                Console.WriteLine(regex.Match(input));
            }
        }
    }
}
