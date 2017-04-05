using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInTheFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());

            var firstFigureX1 = 0;
            var firstFigureY1 = h;
            var firstFigureX2 = 4 * h;
            var firstFigureY2 = 2 * h;
            var secoundFigureX1 = 0;
            var secoundFigureY1 = 0;
            var secoundFigureX2 = h;
            var secoundFigureY2 = 3 * h;
            var firstFigureIsItInside = false;
            var secoundFigureIsItInside = false;

            if (x >= firstFigureX1 &&
                x <= firstFigureX2 &&
                y >= firstFigureY1 &&
                y <= firstFigureY2)
            {
                firstFigureIsItInside = true;
            }
            if (x >= secoundFigureX1 &&
                x <= secoundFigureX2 &&
                y >= secoundFigureY1 &&
                y <= secoundFigureY2)
            {
                secoundFigureIsItInside = true;
            }
            if (firstFigureIsItInside && secoundFigureIsItInside)
            {
                Console.WriteLine("true");
            }
        }
    }
}
