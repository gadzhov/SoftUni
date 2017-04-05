using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var leftSide = 0;
            var rightSide = 0;

            for (int i = 0; i < n; i++)
            {
                leftSide += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                rightSide += int.Parse(Console.ReadLine());
            }
            if (leftSide == rightSide)
            {
                Console.WriteLine("Yes, sum = {0}", rightSide);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(leftSide - rightSide));
            }
        }
    }
}
