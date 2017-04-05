using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000_Days_After_Birth
{
    class Program
    {
        static void Main(string[] args)
        {
            string fdt = "dd-MM-yyyy";
            string input = Console.ReadLine();
            DateTime userBirthay = DateTime.ParseExact(input, fdt, null);
            Console.WriteLine(userBirthay.AddYears(65).ToString("dd-MM-yyyy"));
        }
    }
}
