using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8.Raw_Data
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var company = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carArg = Console.ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var model = carArg[0];
                var engineSpeed = int.Parse(carArg[1]);
                var enginePower = int.Parse(carArg[2]);
                var cargoWeight = int.Parse(carArg[3]);
                var cargoType = carArg[4];
                var tire1Pressure = double.Parse(carArg[5]);
                var tire1Age = int.Parse(carArg[6]);
                var tire2Pressure = double.Parse(carArg[7]);
                var tire2Age = int.Parse(carArg[8]);
                var tire3Pressure = double.Parse(carArg[9]);
                var tire3Age = int.Parse(carArg[10]);
                var tire4Pressure = double.Parse(carArg[11]);
                var tire4Age = int.Parse(carArg[12]);

                var engine = new Engine()
                {
                    EnginePower = enginePower,
                    EngineSpeed = engineSpeed
                };

                var cargo = new Cargo()
                {
                    CargoType = cargoType,
                    CargoWeight = cargoWeight
                };

                var tire1 = new Tire()
                {
                    TirePressure = tire1Pressure,
                    TireAge = tire1Age
                };
                var tire2 = new Tire()
                {
                    TirePressure = tire2Pressure,
                    TireAge = tire2Age
                };
                var tire3 = new Tire()
                {
                    TirePressure = tire3Pressure,
                    TireAge = tire3Age
                };
                var tire4 = new Tire()
                {
                    TirePressure = tire4Pressure,
                    TireAge = tire4Age
                };

                var car = new Car()
                {
                    Model = model,
                    Engine = engine,
                    Cargo = cargo,
                    Tires = new List<Tire>()
                };
                car.Tires.Add(tire1);
                car.Tires.Add(tire2);
                car.Tires.Add(tire3);
                car.Tires.Add(tire4);

                company.Add(car);
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            {
                company
                    .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.TirePressure < 1))
                    .Select(c => c.Model)
                    .ToList()
                    .ForEach(Console.WriteLine);       
            }
            else
            {
                company
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                    .Select(c => c.Model)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
    }
}
