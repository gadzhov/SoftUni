public abstract class Bender
{
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; set; }

    public int Power { get; set; }
}