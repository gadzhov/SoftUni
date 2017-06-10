using System;
using System.Numerics;

namespace _5.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Trim().Split();
            var baseN = int.Parse(line[0]);
            var number = line[1].ToCharArray();
            var result = new BigInteger(0);
            for (int i = number.Length - 1, n = 0; i >= 0; i--, n++)
            {
                var num = new BigInteger(char.GetNumericValue(number[n]));
                var forSum = BigInteger.Multiply(num, BigInteger.Pow(new BigInteger(baseN), i));
                result += forSum;
            }
            Console.WriteLine(result.ToString());
        }
    }
}
