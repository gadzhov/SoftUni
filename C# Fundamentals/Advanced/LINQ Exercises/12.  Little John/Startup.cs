using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12.Little_John
{
    class Startup
    {
        static void Main(string[] args)
        {
            const string pattern = "(?<large>>>>----->>)|(?<medium>>>----->)|(?<small>>----->)";
            var regex = new Regex(pattern);

            var large = 0;
            var medium = 0;
            var small = 0;

            for (int i = 0; i < 4; i++)
            {
                var text = Console.ReadLine();
                foreach (Match match in regex.Matches(text))
                {
                    if (match.Groups["large"].Success)
                    {
                        large++;
                    }
                    if (match.Groups["medium"].Success)
                    {
                        medium++;
                    }
                    if (match.Groups["small"].Success)
                    {
                        small++;
                    }
                }
            }

            var concat = int.Parse(small.ToString() + medium.ToString() + large.ToString());
            var binary = Convert.ToString(concat, 2);
            var revercedBinary = Reverce(binary);
            var mirror = Reverce(revercedBinary) + revercedBinary;
            var dec = Convert.ToInt64(mirror, 2);
            Console.WriteLine(dec);
        }

        private static string Reverce(string str)
        {
            var result = string.Empty;
            for (var i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }

            return result;
        }
    }
}
