using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7.Speed_Racing
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var car = new Car()
                {
                    Model = carArgs[0],
                    FuleAmount = int.Parse(carArgs[1]),
                    FuleConsumption = double.Parse(carArgs[2]),
                    DistanceTraveled = 0
                };

                cars.Add(car);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var carTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = carTokens[1];
                var amountOfKm = int.Parse(carTokens[2]);

                Car.Drive(cars, model, amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuleAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
