using System;

namespace Problem_1.Vehicles.Models
{
    class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        private double FuelQuantity { get; set; }

        protected double FuelConsumption { get; set; }

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
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.FuelQuantity:F2}";
        }
    }
}
