using System.Text;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model { get; set; }

    public string Color { get; set; }

    public int Battery { get; set; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} Seat {this.Model} with {this.Battery} Batteries")
            .AppendLine($"{this.Start()}")
            .Append($"{this.Stop()}");

        return sb.ToString();
    }
}
