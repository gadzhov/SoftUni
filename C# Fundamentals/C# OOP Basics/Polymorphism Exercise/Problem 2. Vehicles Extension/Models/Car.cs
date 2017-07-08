using System;

namespace Problem_2.Vehicles_Extension.Models
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.FuelConsumption += 0.9;
        }

        public override void Refuel(double liters)
        {
            if (base.FuelQuantity + liters > base.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            base.Refuel(liters);
        }
    }
}
