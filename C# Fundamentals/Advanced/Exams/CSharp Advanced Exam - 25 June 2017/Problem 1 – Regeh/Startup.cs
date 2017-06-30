using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_1___Regeh
{
    class Startup
    {
        static void Main(string[] args)
        {
            // 90/100
            const string pattern = "((\\[([^\\s][A-Za-z]+?)<((?<indexOne>\\d*)REGEH+(?<indexTwo>\\d*))>([^\\s]+?)]))";
            var text = Console.ReadLine();
            var regex = new Regex(pattern);
            var indexes = new List<int>();

            foreach (Match match in regex.Matches(text))
            {
                int indexOne;
                int.TryParse(match.Groups["indexOne"].Value, out indexOne);
                int indexTwo;
                int.TryParse(match.Groups["indexTwo"].Value, out indexTwo);
                indexes.Add(indexOne);
                indexes.Add(indexTwo);
            }
            var sumOfIndexes = 0;
            var result = new StringBuilder();
            foreach (var index in indexes)
            {
                try
                {
                    sumOfIndexes += index;
                    result.Append(text[sumOfIndexes]);
                }
                catch
                {
                    sumOfIndexes %= text.Length - 1;
                    result.Append(text[sumOfIndexes]);
                }
            }
            if (result.Length > 0)
            {
                Console.WriteLine(result);
            }
        }
    }
}
