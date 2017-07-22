using System;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; set; }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"{this.Stars} *";
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.Stars += tuneIndex;
    }
}
