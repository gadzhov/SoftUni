using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccurrencesInString
{
    class OccurrencesInString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int offset = -1;
            int count = 0;
            while (true)
            {
                offset = text.IndexOf(word, offset + 1);
                if (offset == -1)
                {
                    break;
                }
                count++;
            }
            Console.WriteLine($"Ocurrrencies: {count}");
        }
    }
}
