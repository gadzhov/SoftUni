using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sieveArray = new int[n];


            for (int i = 2; i < n; i++)
            {
                if (sieveArray[i] == 0)
                {
                    for (int j = i * i; j < n; j += i)
                    {
                        sieveArray[j] = -1;
                    }
                }
            }
            sieveArray[0] = sieveArray[1] = -1;
            for (int i = 2; i < sieveArray.Length; i++)
            {
                if (sieveArray[i] != -1)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
