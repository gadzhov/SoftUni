namespace Problem_3.Ferrari.Entities.Interfaces
{
    public interface ICar
    {
        string Brand { get; set; }

        string Model { get; set; }

        string Driver { get; set; }

        string Start();

        string Stop();
    }
}
