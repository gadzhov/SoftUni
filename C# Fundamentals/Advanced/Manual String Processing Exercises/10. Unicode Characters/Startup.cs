using System;
using System.Text;

namespace _10.Unicode_Characters
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var result = new StringBuilder();

            foreach (var c in text)
            {
                var escaped = GetEscapeSequence(c);
                result.Append(escaped);
            }

            Console.WriteLine(result);
        }
        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}
