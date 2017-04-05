using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Utilities
{
    class Startup
    {
        public class MathUtil
        {
            public static double Sum(double a, double b)
            {
                return a + b;
            }
            public static double Subtract(double a, double b)
            {
                return a - b;
            }
            public static double Multiply(double a, double b)
            {
                return a * b;
            }
            public static double Divide(double a, double b)
            {
                return a / b;
            }
            public static double Percantage(double a, double b)
            {
                return a * b / 100;
            }
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input != "End")
            {
                var command = input.Split(' ');
                var method = command[0];
                var a = double.Parse(command[1]);
                var b = double.Parse(command[2]);
                switch (method)
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(a, b):F2}");
                        ; break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Subtract(a, b):f2}");
                        ; break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(a, b):F2}");
                        ; break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(a, b):F2}");
                        ; break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percantage(a, b):F2}");
                        ; break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
