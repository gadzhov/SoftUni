using System;
using System.Linq;

namespace Problem_2___Parking_System
{
    class Startup
    {
        // 80/100
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            // init parking lot
            var parking = new bool[dimensions[0]][];
            for (int rowIndex = 0; rowIndex < parking.Length; rowIndex++)
            {
                parking[rowIndex] = new bool[dimensions[1]];
            }

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                var inputTokens = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var entryRow = inputTokens[0];
                var desiredRow = inputTokens[1];
                var desiredCol = inputTokens[2];
                // if is free(default bool false)
                int distance;
                if (!parking[desiredRow][desiredCol])
                {
                    parking[desiredRow][desiredCol] = true;
                    distance = Math.Abs(entryRow - desiredRow) + desiredCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    var closer = parking[desiredRow].Length;
                    var min = parking[desiredRow].Length;
                    var currentDeffernce = 0;
                    for (int i = parking[desiredRow].Length - 1; i > 0; i--)
                    {
                        currentDeffernce = Math.Abs(i - desiredCol);
                        if (currentDeffernce <= min && !parking[desiredRow][i])
                        {
                            min = currentDeffernce;
                            closer = i;
                        }
                    }
                    // Not found free spot
                    if (closer == parking[desiredRow].Length)
                    {
                        Console.WriteLine($"Row {desiredRow} full");
                    }
                    else
                    {
                        parking[desiredRow][closer] = true;
                        distance = Math.Abs(entryRow - desiredRow) + closer + 1;
                        Console.WriteLine(distance);
                    }
                }
            }
        }
    }
}
