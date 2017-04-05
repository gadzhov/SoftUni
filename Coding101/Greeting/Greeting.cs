using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    class Greeting
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string ageStr = Console.ReadLine();
            int age = int.Parse(ageStr);

            Console.WriteLine($"Hello, {firstName} {lastName}. \r\nYou are {age} years old.");
        }
    }
}
