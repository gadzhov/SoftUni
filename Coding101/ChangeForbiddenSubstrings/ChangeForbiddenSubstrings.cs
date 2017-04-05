using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeForbiddenSubstrings
{
    class ChangeForbiddenSubstrings
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = Console.ReadLine().Split(' ').ToArray();
            foreach (var item in words)
            {
                text = text.Replace(item, new string('*', item.Length));
            }
            Console.WriteLine(text);
        }
    }
}
