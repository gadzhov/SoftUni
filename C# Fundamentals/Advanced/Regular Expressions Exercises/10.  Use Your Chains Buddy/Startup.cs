using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.Use_Your_Chains_Buddy
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            const string pattern = "(?<=<p>).*?(?=<\\/p>)";
            var regex = new Regex(pattern);
            var sb = new StringBuilder();


            foreach (Match match in regex.Matches(text))
            {
                var replaced = Regex.Replace(match.ToString(), "[^a-z0-9]", " ");
                for (var i = 0; i < replaced.Length; i++)
                {
                    char ch = replaced[i];
                    if (char.IsLower(replaced[i]))
                    {
                        if (replaced[i] < 110)
                        {
                            sb.Append((char)(ch + 13));
                        }
                        else if (replaced[i] >= 110)
                        {
                            sb.Append((char)(ch - 13));
                        }
                    }
                    else
                    {
                        sb.Append(replaced[i]);
                    }
                }
            }
            Console.WriteLine(Regex.Replace(sb.ToString(), "\\s+", " "));
        }
    }
}
