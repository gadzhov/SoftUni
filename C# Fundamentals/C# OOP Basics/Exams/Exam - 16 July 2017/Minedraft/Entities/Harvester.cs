using System;
using System.Text;

public abstract class Harvester
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public abstract string Id { get; set; }

    public abstract double OreOutput { get; protected set; }
    

    public abstract double EnergyRequirement { get; protected set; }
    

    public abstract string GetName();

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetName()} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}
