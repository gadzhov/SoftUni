using System;
using System.Text.RegularExpressions;

namespace _1.Match_Count
{
    class Startup
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(pattern);
            var count = regex.Matches(text).Count;

            Console.WriteLine(count);
        }
    }
}
