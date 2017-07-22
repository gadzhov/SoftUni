using System.Text;

public abstract class Car
{
    public Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        HorsePower = horsePower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
    }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int YearOfProduction { get; set; }

    public int HorsePower { get; set; }

    public int Acceleration { get; set; }

    public int Suspension { get; set; }

    public int Durability { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s")
            .Append($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }

    public int OverallPerformance()
    {
        return this.HorsePower / this.Acceleration + this.Suspension + this.Durability;
    }

    public int EnginePerformance()
    {
        return this.HorsePower / this.Acceleration;
    }

    public int SuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }
}