using System;
using System.Text;

namespace _7.Sum_big_numbers
{
    class Startup
    {
        static void Main(string[] args)
        {

            var num1 = Console.ReadLine();
            var num2 = Console.ReadLine();

            if (num1.Length >= num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }

            Console.WriteLine(SumRealyBigNumber(num1, num2).TrimStart('0'));
        }

        private static string SumRealyBigNumber(string num1, string num2)
        {
            var p = 0;

            var sb = new StringBuilder();

            for (var i = num1.Length - 1; i >= 0; i--)
            {
                var n1 = int.Parse(num1[i].ToString());
                var n2 = int.Parse(num2[i].ToString());
                var sum = n1 + n2 + p;
                p = sum / 10;
                var result = sum.ToString();
                sb.Append(result[result.Length - 1].ToString());
            }

            sb.Append(p.ToString());

            return Reverse(sb.ToString());
        }

        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
