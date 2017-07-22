using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        base.HorsePower = (int) (base.HorsePower * 1.5);
        base.Suspension = (int) (base.Suspension - base.Suspension * 0.25);
    }

    public IReadOnlyList<string> AddOns
    {
        get => this.addOns.AsReadOnly();
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine +
               $"Add-ons: {(this.addOns.Count > 0 ? string.Join(", ", this.AddOns) : "None")}";
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }
}
