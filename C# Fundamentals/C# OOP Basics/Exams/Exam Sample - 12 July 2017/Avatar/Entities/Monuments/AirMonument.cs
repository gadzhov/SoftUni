﻿public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override string ToString()
    {
        return $"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity:F2}";
    }

    public override int GetBonus()
    {
        return this.AirAffinity;
    }
}
