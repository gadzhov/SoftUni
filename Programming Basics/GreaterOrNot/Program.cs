using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOrNot
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNum = int.Parse(Console.ReadLine());
            var secondNum = int.Parse(Console.ReadLine());

            if (firstNum > secondNum)
            {
                Console.WriteLine("Greater number: " + firstNum);
            }
            else
            {
                Console.WriteLine("Greater number: " + secondNum);
            }
        }
    }
}
