using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10.Car_Salesman
{
    class Startup
    {
        static void Main(string[] args)
        {
            var numberOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();
            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineArgs = Console.ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var eModel = engineArgs[0];
                var ePower = int.Parse(engineArgs[1]);
                var eDisplacement = "n/a";
                var eEfficiency = "n/a";

                if (engineArgs.Length == 3)
                {
                    if (int.TryParse(engineArgs[2], out var tempInt))
                    {
                        eDisplacement = engineArgs[2];
                    }
                    else
                    {
                        eEfficiency = engineArgs[2];
                    }
                }
                else if (engineArgs.Length == 4)
                {
                    eDisplacement = engineArgs[2];
                    eEfficiency = engineArgs[3];
                }
                engines.Add(new Engine
                {
                    Model = eModel,
                    Power = ePower,
                    Displacement = eDisplacement,
                    Efficiency = eEfficiency
                });
            }
            var numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                var carArgs = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                // “<Model> <Engine> <Weight> <Color>”
                var cModel = carArgs[0];
                var cEngine = engines.FirstOrDefault(e => e.Model == carArgs[1]);
                var cWeight = "n/a";
                var cColor = "n/a";

                if (carArgs.Length == 3)
                {
                    if (int.TryParse(carArgs[2], out var tempInt))
                    {
                        cWeight = carArgs[2];
                    }
                    else
                    {
                        cColor = carArgs[2];
                    }
                }
                else if (carArgs.Length == 4)
                {
                    cWeight = carArgs[2];
                    cColor = carArgs[3];
                }

                cars.Add(new Car
                {
                    Model = cModel,
                    Engine = cEngine,
                    Weight = cWeight,
                    Color = cColor
                });
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
