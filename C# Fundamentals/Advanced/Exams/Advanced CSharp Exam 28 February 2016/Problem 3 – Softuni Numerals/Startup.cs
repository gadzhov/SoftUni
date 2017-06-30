using System;
using System.Numerics;

namespace Problem_3___Softuni_Numerals
{
    class Startup
    {
        public static void Main()
        {
            string base5string = ConvertStringToBase5(Console.ReadLine());
            Console.WriteLine(ConvertBase5toBase10(base5string));
        }

        private static string ConvertStringToBase5(string str)
        {
            string[] digitCodes = { "aa", "aba", "bcc", "cc", "cdc" };

            string result = string.Empty;
            while (str.Length > 0)
            {
                for (int index = 0; index < digitCodes.Length; index++)
                {
                    string code = digitCodes[index];
                    if (str.StartsWith(code))
                    {
                        result += index;
                        str = str.Substring(code.Length);
                        break;
                    }
                }
            }

            return result;
        }

        private static BigInteger ConvertBase5toBase10(string base5string)
        {
            BigInteger result = 0;
            for (int index = 0; index < base5string.Length; index++)
            {
                BigInteger nextDigit = base5string[base5string.Length - 1 - index] - '0';
                result += nextDigit * BigInteger.Pow(5, index);
            }

            return result;
        }
    }
}
