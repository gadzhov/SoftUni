using System;
using System.Collections.Generic;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<Car>();
    }

    public IReadOnlyList<Car> ParkedCars
    {
        get => this.parkedCars.AsReadOnly();
    }

    public void ParkCar(Car car)
    {
        this.parkedCars.Add(car);
    }

    public void UnparkCar (Car car)
    {
        this.parkedCars.Remove(car);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in this.parkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }

    public bool IsInGarage(Car car)
    {
        return this.parkedCars.Contains(car);
    }
}
