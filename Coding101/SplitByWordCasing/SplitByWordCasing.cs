using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] seperator = new char[] { ',', ';',':','.', '!', '(', ')', '\"', '\'', '/', '\\', '[', ']', ' ' };
            List<string> text = Console.ReadLine().Split(seperator, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> uppserCase = new List<string>();
            foreach (var words in text)
            {
                int lower = 0;
                int upper = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (char.IsLower(words[i]))
                    {
                        lower++;
                    }
                    else if (char.IsUpper(words[i]))
                    {
                        upper++;
                    }
                }
                if (lower == words.Length)
                {
                    lowerCase.Add(words);
                }
                else if (upper == words.Length)
                {
                    uppserCase.Add(words);
                }
                else
                {
                    mixedCase.Add(words);
                }
            }
            Console.WriteLine($"Lower-case: {string.Join(", ",lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ",mixedCase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ",uppserCase)}");
        }
    }
}
