using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_3___Jedi_Code_X
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            var names = new List<string>();
            var messages = new List<string>();

            for (int i = 0; i < n; i++)
            {
                text.Append(Console.ReadLine() + Environment.NewLine);
            }


            var pattern = Console.ReadLine();
            foreach (Match match in Regex.Matches(text.ToString(), $"{pattern}(?<code>[A-Za-z]{{{pattern.Length}}})(?=[^a-z])"))
            {
                names.Add(match.Groups["code"].Value);
            }
            pattern = Console.ReadLine();
            foreach (Match match in Regex.Matches(text.ToString(), $"{pattern}(?<code>[A-Za-z0-9]{{{pattern.Length}}})(?=[^a-z])"))
            {
                messages.Add(match.Groups["code"].Value);
            }

            var indexex = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var position = 0;
            for (int i = 0; i < names.Count; i++)
            {
                try
                {
                    Console.WriteLine($"{names[i]} - {messages[indexex[position] - 1]}");
                    position++;
                }
                catch
                {
                    //ignore
                }
            }

        }
    }
}
