using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public abstract class Race
{
    public Race(int length, string route, int prizePool)
    {
        Length = length;
        Route = route;
        PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public int Length { get; set; }

    public string Route { get; set; }

    public int PrizePool { get; set; }

    public Dictionary<int, Car> Participants { get; set; }

    public void AddParticipants(int carId, Car car)
    {
        this.Participants.Add(carId, car);
    }

    public bool IsRacing(int carId)
    {
        return this.Participants.Any(c => c.Key == carId);
    }

    public abstract List<Car> GetWinners();

    public abstract string GetPrizePool();

    protected void DecreaseDurability(int multiplyier)
    {
        foreach (var car in this.Participants.Values)
        {
            car.Durability -= multiplyier;
        }
    }
}
