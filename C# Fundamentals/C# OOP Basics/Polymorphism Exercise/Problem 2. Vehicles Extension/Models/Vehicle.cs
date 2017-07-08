using System;

namespace Problem_2.Vehicles_Extension.Models
{
    class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected double FuelQuantity { get; private set; }

        protected double FuelConsumption { get; set; }

        protected double TankCapacity { get; }

        public void Driving(double distance)
        {
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
