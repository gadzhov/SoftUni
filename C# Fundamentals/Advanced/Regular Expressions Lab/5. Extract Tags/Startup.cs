using System;
using System.Text.RegularExpressions;

namespace _5.Extract_Tags
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            const string pattern = "<.+?>";
            var regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "END")
            {
                if (regex.IsMatch(input))
                {
                    foreach (Match match in regex.Matches(input))
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}
