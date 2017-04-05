using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterEvenNumber
{
    class EnterEvenNumber
    {
        static void Main(string[] args)
        {
            var isItEven = false;
            var num = 0;
            while (isItEven == false)
            {
                try
                {
                    Console.Write("Enter Even number:");
                    num = int.Parse(Console.ReadLine());
                    if (num % 2 == 0)
                    {
                        isItEven = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number is not even:");
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid number!");
                    
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Invalid number!");
                }
                
            }
            Console.WriteLine("Even number entered: {0}", num);
        }
    }
}
