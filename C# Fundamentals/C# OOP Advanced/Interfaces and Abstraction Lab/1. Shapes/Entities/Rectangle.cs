using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Height
    {
        get { return height; }
        private set { height = value; }
    }


    public int Width
    {
        get { return width; }
        private set { width = value; }
    }


    public void Draw()
    {
        DrawLine(this.Width, '*', '*');
        for (var i = 1; i < this.Height - 1; ++i)
            DrawLine(this.Width, '*', ' ');
        DrawLine(this.Width, '*', '*');
    }
    private static void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);
        for (var i = 1; i < width - 1; ++i)
            Console.Write(mid);
        Console.WriteLine(end);
    }

}
