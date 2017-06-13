using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _9.Query_Mess
{
    class Startup
    {
        static void Main()
        {
            const string pattern = "(?<key>[^=&?]+)=(?<value>[^&]+)";
            string input;
            var regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "END")
            {
                var result = new Dictionary<string, List<string>>();

                foreach (Match match in regex.Matches(input))
                {
                    var key = Regex.Replace(match.Groups["key"].Value, "((%20|\\+)+)", " ").Trim();
                    var value = Regex.Replace(match.Groups["value"].Value, "((%20|\\+)+)", " ").Trim();

                    if (!result.ContainsKey(key))
                    {
                        result.Add(key, new List<string>());
                        result[key].Add(value);
                    }
                    else
                    {
                        result[key].Add(value);
                    }
                }

                foreach (var pair in result)
                {
                    Console.Write(pair.Key + "=["+ string.Join(", ", pair.Value) +"]");
                }
                Console.WriteLine();

            }
        }
    }
}
