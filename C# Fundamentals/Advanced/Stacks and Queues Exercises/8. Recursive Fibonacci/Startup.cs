using System;

namespace _8.Recursive_Fibonacci
{
    class Startup
    {
        private static long[] fibNumbers;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            fibNumbers = new long[n];
            var result = GetFibonacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }
            return fibNumbers[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
