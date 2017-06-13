using System;
using System.Text.RegularExpressions;

namespace _7.Valid_Time
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            const string pattern = @"^(0[0-9]|1[012]):[0-5][0-9]:[0-5][0-9] [AP]M$";
            var regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "END")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
