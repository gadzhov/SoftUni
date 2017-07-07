using System;

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double Radius
    {
        get => _radius;
        set => _radius = value;
    }


    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(this.Radius, 2);
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
