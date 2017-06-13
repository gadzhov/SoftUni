using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Replace_a_tag
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            const string pattern = "<a(.+?)>(.+)<\\/a>";
            var regex = new Regex(pattern);


            while ((input = Console.ReadLine()) != "end")
            {
                if (regex.Match(input).Success)
                {
                    Console.WriteLine(regex.Replace(input, "[URL$1]$2[/URL]"));
                }
                else
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
