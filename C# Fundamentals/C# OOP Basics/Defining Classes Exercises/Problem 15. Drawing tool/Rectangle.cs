using System;

namespace Problem_15.Drawing_tool
{
    public class Rectangle
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public void Draw()
        {
            Console.WriteLine($"|{new string('-', Width)}|");
            for (int HeightIndex = 0; HeightIndex < Height - 2; HeightIndex++)
            {
            Console.WriteLine($"|{new string(' ', Width)}|");
            }
            Console.WriteLine($"|{new string('-', Width)}|");
        }
    }
}
