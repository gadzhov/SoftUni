using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        Car car;
        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension,
                    durability);
                break;
            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            default:
                throw new InvalidOperationException("Invalid Car Type!");
        }

        this.cars.Add(id, car);
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void OpenSpeacial(int id, string type, int length, string route, int prizePool, int specialProp)
    {
        Race race;
        switch (type)
        {
            case "TimeLimit":
                race = new TimeLimitRace(length, route, prizePool, specialProp);
                break;
            case "Circuit":
                race = new CircuitRace(length, route, prizePool, specialProp);
                break;
            default:
                throw new InvalidOperationException("Invalid Race Type!");
        }

        this.races.Add(id, race);
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race;
        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool);
                break;
            case "Drag":
                race = new DragRace(length, route, prizePool);
                break;
            case "Drift":
                race = new DriftRace(length, route, prizePool);
                break;
            default:
                throw new InvalidOperationException("Invalid Race Type!");
        }
        this.races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        var car = this.cars[carId];
        var race = this.races[raceId];
        if (race.GetType().Name == "TimeLimitRace")
        {
            var r = race as TimeLimitRace;
            if (r.IsRaceFree())
            {
                race.AddParticipants(carId, car);
            }
        }
        else if (!this.garage.IsInGarage(car))
        {
            this.races[raceId].AddParticipants(carId, car);
        }
    }

    public string Start(int id)
    {
        var currentRace = this.races[id];
        if (currentRace.Participants.Count == 0)
        {
            throw new InvalidOperationException("Cannot start the race with zero participants.");
        }
        this.races.Remove(id);

        return currentRace.GetPrizePool().Trim();
    }

    public void Park(int id)
    {
        var car = this.cars[id];
        if (this.races.Count != 0)
        {
            foreach (var race in this.races)
            {
                if (!race.Value.IsRacing(id) && !this.garage.IsInGarage(car))
                {
                    this.garage.ParkCar(car);
                }
            }
        }
        else
        {
            this.garage.ParkCar(car);
        }

    }

    public void Unpark(int id)
    {
        var car = this.cars[id];
        this.garage.UnparkCar(car);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (this.garage.ParkedCars.Count > 0)
        {
            this.garage.Tune(tuneIndex, addOn);
        }
    }
}
