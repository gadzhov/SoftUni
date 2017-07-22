using System;

class HammerHarvester : Harvester
{
    private double oreOutput;
    private double energyRequirement;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string Id { get; set; }

    public override double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public override double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value <= 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public override string GetName()
    {
        return "Hammer";
    }
}