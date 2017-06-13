using System;
using System.Text.RegularExpressions;

namespace _2.Match_Phone_Number
{
    class Startup
    {
        static void Main(string[] args)
        {
            const string pattern = "\\+359( |-)2\\1([0-9]{3})\\1([0-9]{4})\\b";
            var regex = new Regex(pattern);
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                foreach (Match match in regex.Matches(input))
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
