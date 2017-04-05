using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestCommonDivior
{
    class GreatestCommonDivior
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            
            while (b != 0)
            {
                var oldB = b;
                b = a % b;
                a = oldB;
            }
            Console.WriteLine(a);
        }
    }
}
