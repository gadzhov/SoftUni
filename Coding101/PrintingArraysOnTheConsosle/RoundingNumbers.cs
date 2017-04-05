using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNumbers
{
    class RoundingNumbers
    {
        static void Main(string[] args)
        {
            double[] roundingNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            for (int i = 0; i < roundingNumbers.Length; i++)
            {
                Console.WriteLine(roundingNumbers[i]);
                roundingNumbers[i] = (int)Math.Round(roundingNumbers[i],MidpointRounding.AwayFromZero);
                Console.WriteLine(roundingNumbers[i]);
            }
        }
    }
}
