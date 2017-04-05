using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloName
{
    class HelloName
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintHello(name);
        }
        static void PrintHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
