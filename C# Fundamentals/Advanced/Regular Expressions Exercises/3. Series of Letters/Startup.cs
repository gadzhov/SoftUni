using System;
using System.Text.RegularExpressions;

namespace _3.Series_of_Letters
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            const string pattern = "(.)\\1+";
            var regex = new Regex(pattern);
            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}
