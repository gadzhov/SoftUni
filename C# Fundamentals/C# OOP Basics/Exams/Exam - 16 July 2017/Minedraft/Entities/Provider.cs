using System;
using System.Text;

public abstract class Provider
{
    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public abstract string Id { get; set; }

    public abstract double EnergyOutput { get; protected set; }

    public abstract string GetName();

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetName()} Provider - {this.Id}")
            .Append($"Energy Output: {this.EnergyOutput}");

        return sb.ToString();
    }
}