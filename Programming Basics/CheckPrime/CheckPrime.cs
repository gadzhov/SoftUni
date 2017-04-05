using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPrime
{
    class CheckPrime
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var diveder = 2;
            var isPrime = true;
            if (n < 2)
            {
                isPrime = false;
            }
            else
            {
                while (isPrime == true && diveder < n)
                {
                    if (n % diveder != 0)
                    {
                        isPrime = true;
                    }
                    else
                    {
                        isPrime = false;
                        break;
                    }
                    diveder++;
                }
            }
            if (isPrime == true)
            {
                Console.WriteLine("Prime");
            }
            else
            {
                Console.WriteLine("Not Prime");
            }
        }
    }
}
