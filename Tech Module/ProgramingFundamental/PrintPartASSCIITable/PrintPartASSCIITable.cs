using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPartASSCIITable
{
    class PrintPartASSCIITable
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (char i = (char)start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}
