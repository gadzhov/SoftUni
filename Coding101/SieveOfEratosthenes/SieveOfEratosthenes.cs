using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
            }
            primes[0] = primes[1] = false;
            for (int p = 2; p <= n; p++)
            {
                if (primes[p])
                {
                    FillPrimes(primes, p);
                    Console.WriteLine(p);
                }
            }
        }
        static void FillPrimes(bool[] primes, int step)
        {
            for (int i = 2 * step; i < primes.Length; i += step)
            {
                primes[i] = false;
            }
        }
    }
}
