using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseCharacters
{
    class ReverseCharacters
    {
        static void Main(string[] args)
        {
            string[] result = new string[3];
            for (int i = 2; i >= 0; i--)
            {
                string ch = Console.ReadLine();
                result[i] = ch;
            }
            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
