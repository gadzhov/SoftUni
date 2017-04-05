using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = 1;
            var b = 1;
            var fibo = 0;
            while (n > 1)
            {
                fibo = a + b;
                a = b;
                b = fibo;
                n--;
            }
            Console.WriteLine(b);
        }
    }
}
