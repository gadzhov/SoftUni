using System;
using System.Text;

namespace _5.Concatenate_Strings
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var text = Console.ReadLine();
                sb.Append(text).Append(" ");
            }

            Console.WriteLine(sb);
        }
    }
}
