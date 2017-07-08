using System;
using Problem_1.Vehicles.Models;

namespace Problem_1.Vehicles
{
    class Startup
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int row = 0; row < numberOfCommands; row++)
            {
                var commandArgs = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                var vehicle = commandArgs[1];

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Driving(double.Parse(commandArgs[2]));
                    }
                    else
                    {
                        truck.Driving(double.Parse(commandArgs[2]));
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Truck")
                    {
                        truck.Refuel(double.Parse(commandArgs[2]));
                    }
                    else
                    {
                        car.Refuel(double.Parse(commandArgs[2]));
                    }
                }
            }
            Console.WriteLine($"Car: {car}");
            Console.WriteLine($"Truck: {truck}");
        }
    }
}
