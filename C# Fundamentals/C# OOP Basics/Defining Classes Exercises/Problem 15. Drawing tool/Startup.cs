using System;

namespace Problem_15.Drawing_tool
{
    class Startup
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            if (figure == "Rectangle")
            {
                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                var draw = new CorDraw(new Rectangle(width, height));

                draw.Rectangle.Draw();
            }
            else if (figure == "Square")
            {
                var width = int.Parse(Console.ReadLine());
                var height = width;
                var draw = new CorDraw(new Square(width, height));

                draw.Square.Draw();
            }
        }
    }
}
