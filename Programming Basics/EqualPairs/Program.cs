using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var diference = 0;
            var maxDiference = 0;
            var curentSum = 0;
            var previousSum = 0;
            for (int i = 0; i < n; i++)
            {
                previousSum = curentSum;
                curentSum = 0;
                curentSum += int.Parse(Console.ReadLine());
                curentSum += int.Parse(Console.ReadLine());
                if (i != 0)
                {
                    diference = Math.Abs(previousSum - curentSum);
                    if (diference !=0 && diference > maxDiference)
                    {
                        maxDiference = diference;
                    }
                }
                }
                if (previousSum == curentSum || n == 1)
                {
                    Console.WriteLine("Yes, value={0}", curentSum);
                }
                else
                {
                    Console.WriteLine("No, maxdiff={0}", maxDiference);
                }
            }
        }
    }
