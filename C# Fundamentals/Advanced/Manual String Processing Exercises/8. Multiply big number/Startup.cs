using System;
using System.Text;

namespace _8.Multiply_big_number
{
    class Startup
    {
        public static void Main(string[] args)
        {
            var num1 = Console.ReadLine();
            var num2 = Console.ReadLine();

            Console.WriteLine(MultiplyRealyBigNumber(num1, num2));
        }

        private static string MultiplyRealyBigNumber(string num1, string num2)
        {
            var n2 = int.Parse(num2.ToString());

            if (n2 == 0)
            {
                return "0";
            }

            var p = 0;

            var sb = new StringBuilder();

            for (var i = num1.Length - 1; i >= 0; i--)
            {
                var n1 = int.Parse(num1[i].ToString());
                var mult = n2 * n1 + p;
                p = mult / 10;
                var result = mult.ToString();
                sb.Append(result[result.Length - 1].ToString());
            }

            sb.Append(p.ToString());

            return Reverse(sb.ToString()).TrimStart('0');
        }

        private static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
