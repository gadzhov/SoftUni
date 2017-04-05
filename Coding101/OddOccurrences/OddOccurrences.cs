using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .ToLower()
                .Split(' ');
            var count = new Dictionary<string, int>();
            foreach (var word in text)
            {
                if (count.ContainsKey(word))
                {
                    count[word]++;
                }
                else
                {
                    count[word] = 1;
                }
            }
            List<string> result = new List<string>();
            foreach (var item in count.Keys)
            {
                if (count[item] % 2 != 0)
                {
                    result.Add(item);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
