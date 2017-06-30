using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_3___Basic_Mark_up_Language
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            const string pattern =
                "<\\s*(?<command>[a-z]+)\\s+(value\\s*=\\s*\"(?<value>\\d+)\")*\\s*(content\\s*=\\s*\"(?<content>.+)\")*\\3*";
            var regex = new Regex(pattern);
            var line = 1;
            while ((input = Console.ReadLine()) != "<stop/>")
            {
                var match = regex.Match(input);
                var command = match.Groups["command"].Value;
                var value = match.Groups["value"].Value;
                var content = match.Groups["content"].Value;
                switch (command)
                {
                    case "inverse":
                        if (content != "")
                        {
                            Console.Write($"{line}. ");
                            foreach (char t in content)
                            {
                                Console.Write(char.IsLower(t) ? t.ToString().ToUpper() : t.ToString().ToLower());
                            }
                            Console.WriteLine();
                            line++;
                        }
                        break;
                    case "reverse":
                        if (content != "")
                        {
                            Console.Write($"{line}. ");
                            for (int i = content.Length - 1; i >= 0; i--)
                            {
                                Console.Write(content[i]);
                            }
                            Console.WriteLine();
                            line++;
                        }
                        break;
                    case "repeat":
                        for (int i = 0; i < int.Parse(value); i++)
                        {
                            Console.WriteLine($"{line}. {content}");
                            line++;
                        }
                        break;
                }
            }
        }
    }
}
