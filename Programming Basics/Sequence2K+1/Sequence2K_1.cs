using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence2K_1
{
    class Sequence2K_1
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 1;
            while (sum <= n)
            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
            }
        }
    }
}
