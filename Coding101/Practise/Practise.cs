using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    class Practise
    {
        static void Main(string[] args)
        {
            int star = int.Parse(Console.ReadLine());
            PrintFirstLine(star);   
        }
        static void PrintFirstLine(int star)
        {
            Console.WriteLine(new string('*', star));
        }
    }
}
