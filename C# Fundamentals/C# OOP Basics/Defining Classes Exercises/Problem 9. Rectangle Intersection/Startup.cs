using System;
using System.Linq;

namespace Problem_9.Rectangle_Intersection
{
    class Startup
    {
        static void Main(string[] args)
        {
            var counts = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rectangles = new Rectangle[counts[0]];

            for (int i = 0; i < counts[0]; i++)
            {
                var tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var id = tokens[0];
                var width = double.Parse(tokens[1]);
                var height = double.Parse(tokens[2]);
                var x = double.Parse(tokens[3]);
                var y = double.Parse(tokens[4]);

                rectangles[i] = new Rectangle(id, width, height, x, y);
            }

            for (var i = 0; i < counts[1]; i++)
            {
                var tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                var rect1 = rectangles.FirstOrDefault(r => r.id == tokens[0]);
                var rect2 = rectangles.FirstOrDefault(r => r.id == tokens[1]);
                Console.WriteLine(rect1.Intersects(rect2));
            }
        }
    }
}
