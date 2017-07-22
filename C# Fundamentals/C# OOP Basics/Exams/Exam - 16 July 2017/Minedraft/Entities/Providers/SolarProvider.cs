using System;

class SolarProvider : Provider
{
    private double energyOutput;

    public override string Id { get; set; }

    public override double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value <= 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public override string GetName()
    {
        return "Solar";
    }

    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
    }
}
