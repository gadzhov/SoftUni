using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class PrimeChecker
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            bool result = false;
            Console.WriteLine(IsPrime(n, result));
        }
        static bool IsPrime(long n, bool result)
        {
            if (n == 2 || n == 3 || n == 5 || n == 7)
            {
                result = true;
            }
            else
            {
                for (int i = (int)Math.Sqrt(n); i > 3; i--)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
