using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrDigit
{
    class VowelOrDigit
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine().ToLower());
            char[] vowel = new char[] { 'a', 'e', 'i', 'o', 'u' };
            if (char.IsDigit(input))
            {
                Console.WriteLine("digit");
            }
            else if (vowel.Contains(input))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
