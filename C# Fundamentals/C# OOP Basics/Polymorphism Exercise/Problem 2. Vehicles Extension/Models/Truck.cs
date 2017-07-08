using System;

namespace Problem_2.Vehicles_Extension.Models
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.FuelConsumption += 1.6;
        }
 
        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
