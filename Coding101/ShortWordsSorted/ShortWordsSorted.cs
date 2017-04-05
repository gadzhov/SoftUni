using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            char[] separators = ".,:()[]\"'!? ".ToCharArray();
            var result = Console.ReadLine()
                .ToLower()
                .Split(separators)
                .Where(r => r != "")
                .Where(r => r.Length < 5)
                .OrderBy(r => r)
                .Distinct()
                .ToList();
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
