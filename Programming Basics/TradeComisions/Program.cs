using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComisions
{
    class Program
    {
        static void Main(string[] args)
        {
            var town = Console.ReadLine().ToLower();
            var comison = double.Parse(Console.ReadLine());
            var a = -1.0;
            if (town == "sofia")
            {
                if (comison >= 0 && comison <= 500)
                {
                    a = 0.05;
                }
                else if (comison > 500 && comison <= 1000)
                {
                    a = 0.07;
                }
                else if (comison > 1000 && comison <= 10000)
                {
                    a= 0.08;
                }
                else if (comison > 10000)
                {
                    a = 0.12;
                }
            }
            if (town == "varna")
            {
                if (comison >= 0 && comison <= 500)
                {
                    a = 0.045;
                }
                else if (comison > 500 && comison <= 1000)
                {
                    a = 0.075;
                }
                else if (comison > 1000 && comison <= 10000)
                {
                    a = 0.10;
                }
                else if (comison > 10000)
                {
                    a = 0.13;
                }
            }
            else if (town == "plovdiv")
            {
                if (comison >= 0 && comison <= 500)
                {
                    a = 0.055;
                }
                else if (comison > 500 && comison <= 1000)
                {
                    a = 0.08;
                }
                else if (comison > 1000 && comison <= 10000)
                {
                    a = 0.12;
                }
                else if (comison > 10000)
                {
                    a = 0.145;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            if (a == -1.0)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine("{0:f2}", comison * a);
            }
        }
    }
}
