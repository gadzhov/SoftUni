using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bgn = 1;
            var usd = 1.79549;
            var eur = 1.95583;
            var gbp = 2.53405;
            var input = double.Parse(Console.ReadLine());
            var curencyInput = Console.ReadLine();
            var curencyOutput = Console.ReadLine();
            string a = null;
            string b = null;
            var c = 0.0;
            var d = 0.0;
            switch (curencyInput)
            {
                case "BGN": a = "BGN"; break;
                case "USD": a = "USD"; break;
                case "EUR": a = "EUR"; break;
                case "GBP": a = "GBP"; break;
                default: Console.WriteLine("You hae entered wrong curency!");break;
            }
            switch (curencyOutput)
            {
                case "BGN": b = "BGN"; break;
                case "USD": b = "USD"; break;
                case "EUR": b = "EUR"; break;
                case "GBP": b = "GBP"; break;
                default: Console.WriteLine("You hae entered wrong curency!"); break;
            }
            switch (a)
            {
                case "BGN": c = bgn;break;
                case "USD": c = usd; break;
                case "EUR": c = eur; break;
                case "GBP": c = gbp; break;
                default:
                    break;
            }
            switch (b)
            {
                case "BGN": d = bgn; break;
                case "USD": d = usd; break;
                case "EUR": d = eur; break;
                case "GBP": d = gbp; break;
                default:
                    break;
            }
            Console.WriteLine("{0:f2} {1}", input * c / d, b);
        }
    }
}
