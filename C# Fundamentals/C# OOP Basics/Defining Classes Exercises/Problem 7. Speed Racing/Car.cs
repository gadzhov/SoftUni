using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7.Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuleAmount { get; set; }

        public double FuleConsumption { get; set; }

        public int DistanceTraveled { get; set; }

        public static void Drive(List<Car> cars,string model, int amount)
        {
            var carToDrive = cars.FirstOrDefault(c => c.Model == model);
            if (carToDrive.FuleAmount >= amount * carToDrive.FuleConsumption)
            {
                cars.FirstOrDefault(c => c.Model == model).FuleAmount -= amount * carToDrive.FuleConsumption;
                cars.FirstOrDefault(c => c.Model == model).DistanceTraveled += amount;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

        }
    }
}
