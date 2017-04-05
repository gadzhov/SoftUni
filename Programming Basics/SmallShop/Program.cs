using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = Console.ReadLine();
            var town = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            if (town == "Sofia")
            {
                if (item == "coffee")
                {
                    Console.WriteLine(quantity * 0.50);
                }
                else if (item == "water")
                {
                    Console.WriteLine(quantity * 0.80);
                }
                else if (item == "beer")
                {
                    Console.WriteLine(quantity * 1.20);
                }
                else if (item == "sweets")
                {
                    Console.WriteLine(quantity * 1.45);
                }
                else if (item == "peanuts")
                {
                    Console.WriteLine(quantity * 1.60);
                }
            }
            else if (town == "Plovdiv")
            {
                if (item == "coffee")
                {
                    Console.WriteLine(quantity * 0.40);
                }
                else if (item == "water")
                {
                    Console.WriteLine(quantity * 0.70);
                }
                else if (item == "beer")
                {
                    Console.WriteLine(quantity * 1.15);
                }
                else if (item == "sweets")
                {
                    Console.WriteLine(quantity * 1.30);
                }
                else if (item == "peanuts")
                {
                    Console.WriteLine(quantity * 1.50);
                }
            }
            else if (town == "Varna")
            {
                if (item == "coffee")
                {
                    Console.WriteLine(quantity * 0.45);
                }
                else if (item == "water")
                {
                    Console.WriteLine(quantity * 0.70);
                }
                else if (item == "beer")
                {
                    Console.WriteLine(quantity * 1.10);
                }
                else if (item == "sweets")
                {
                    Console.WriteLine(quantity * 1.35);
                }
                else if (item == "peanuts")
                {
                    Console.WriteLine(quantity * 1.55);
                }
            }
        }
    }
}
