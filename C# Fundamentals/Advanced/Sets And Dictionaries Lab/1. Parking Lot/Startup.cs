namespace _1.Parking_Lot
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var parkingLot = new SortedSet<string>();

            while (input != "END")
            {
                var tokens = input.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "IN")
                {
                    parkingLot.Add(tokens[1]);
                }
                else
                {
                    parkingLot.Remove(tokens[1]);
                }

                input = Console.ReadLine();
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
