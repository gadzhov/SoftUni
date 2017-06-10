using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _4.Convert_from_base_10_to_base_N
{
    class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            var n = input[0];
            var decNumber = input[1];

            Console.WriteLine(FromBase10ToBaseNconverter(n, decNumber));
        }

        private static string FromBase10ToBaseNconverter(BigInteger n, BigInteger decNumber)
        {
            var rs = new StringBuilder();

            while (decNumber > 0)
            {
                var rem = decNumber % n;
                rs.Append(rem);
                decNumber = decNumber / n;
            }

            var str = rs.ToString();

            var result = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}

