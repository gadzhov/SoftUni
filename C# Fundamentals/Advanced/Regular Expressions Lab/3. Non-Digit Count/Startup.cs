using System;
using System.Text.RegularExpressions;

namespace _3.Non_Digit_Count
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "[^0-9]";
            var regex = new Regex(pattern);
            var count = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
