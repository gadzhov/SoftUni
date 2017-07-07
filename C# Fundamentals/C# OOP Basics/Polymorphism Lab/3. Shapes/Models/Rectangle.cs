public class Rectangle : Shape
{
    private double _height;
    private double _width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    private double Width
    {
        get => _width;
        set => _width = value;
    }


    private double Height
    {
        get => _height;
        set => _height = value;
    }


    public override double CalculatePerimeter()
    {
        return this.Height * 2 + this.Width * 2;
    }

    public override double CalculateArea()
    {
        return this.Height * this.Width;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
