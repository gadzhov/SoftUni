using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 1;
            int b = 0;
            int fibo = 0;

            Console.WriteLine(Fib(n, a, b, fibo));
        }
        static int Fib(int n, int a, int b, int fibo)
        {
            for (int i = 0; i <= n; i++)
            {
                fibo = a + b;
                a = b;
                b = fibo;

            }
            return fibo;
        }
    }
}
