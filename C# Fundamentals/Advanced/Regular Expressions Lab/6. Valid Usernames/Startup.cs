using System;
using System.Text.RegularExpressions;

namespace _6.Valid_Usernames
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            const string pattern = "^[A-Za-z0-9_-]{3,16}$";
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
