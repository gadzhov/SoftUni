using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planck_Constrant
{
    class Startup
    {
        public class Calculation
        {
            private static double Planck = 6.62606896e-34;
            private static double Pi = 3.14159;

            public static void Reduced()
            {
                Console.WriteLine($"{Planck / (2 * Pi)}");
            }
        }
        static void Main(string[] args)
        {
            Calculation.Reduced();
        }
    }
}
