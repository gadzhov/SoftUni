using System;
using Problem_2.Vehicles_Extension.Models;

namespace Problem_2.Vehicles_Extension
{
    class Startup
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int row = 0; row < numberOfCommands; row++)
            {
                var commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandArgs[0];
                var vehicle = commandArgs[1];

                try
                {
                    if (command == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            car.Driving(double.Parse(commandArgs[2]));
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Driving(double.Parse(commandArgs[2]));
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.DrivingFull();
                            bus.Driving(double.Parse(commandArgs[2]));
                            bus.DrivingEmpty();
                        }

                    }
                    else if (command == "Refuel")
                    {
                        if (vehicle == "Truck")
                        {
                            truck.Refuel(double.Parse(commandArgs[2]));
                        }
                        else if (vehicle == "Car")
                        {
                            car.Refuel(double.Parse(commandArgs[2]));
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(double.Parse(commandArgs[2]));
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.Driving(double.Parse(commandArgs[2]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
