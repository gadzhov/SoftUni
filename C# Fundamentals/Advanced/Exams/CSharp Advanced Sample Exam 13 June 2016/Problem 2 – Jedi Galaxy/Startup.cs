using System;
using System.Linq;

namespace Problem_2___Jedi_Galaxy
{
    class Startup
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var galaxy = new int[dimensions[0]][];

            // init galaxy 0, 1, 2, 3, n
            var counter = 0;
            for (int rowIndex = 0; rowIndex < galaxy.Length; rowIndex++)
            {
                galaxy[rowIndex] = new int[dimensions[1]];
                for (int colIndex = 0; colIndex < galaxy[rowIndex].Length; colIndex++)
                {
                    galaxy[rowIndex][colIndex] = counter;
                    counter++;
                }
            }

            string input;
            var totalPoints = 0L;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                var inputTokens = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var playerRowPosition = inputTokens[0];
                var playerColPosition = inputTokens[1];

                inputTokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilRowPosition = inputTokens[0];
                var evilColPosition = inputTokens[1];

                galaxy = DestroyStars(galaxy, evilRowPosition, evilColPosition);
                totalPoints += CollectPoints(galaxy, playerRowPosition, playerColPosition);
            }
            Console.WriteLine(totalPoints);
        }

        private static long CollectPoints(int[][] galaxy, int playerRowPosition, int playerColPosition)
        {
            var currentPoints = 0L;
            var count = playerRowPosition;
            for (int i = 0; i < count + 1; i++)
            {
                if (playerRowPosition >= 0 && playerRowPosition < galaxy.Length && playerColPosition >= 0 && playerColPosition < galaxy[playerRowPosition].Length)
                {
                    currentPoints += galaxy[playerRowPosition][playerColPosition];
                    playerRowPosition--;
                    playerColPosition++;
                }
                else
                {
                    playerRowPosition--;
                    playerColPosition++;
                }
            }
            return currentPoints;
        }

        private static int[][] DestroyStars(int[][] galaxy, int evilRowPosition, int evilColPosition)
        {
            var count = evilRowPosition;
            for (int i = 0; i < count + 1; i++)
            {
                if (evilRowPosition >= 0 && evilRowPosition < galaxy.Length && evilColPosition >= 0 && evilColPosition < galaxy[evilRowPosition].Length)
                {
                    galaxy[evilRowPosition][evilColPosition] = 0;
                    evilRowPosition--;
                    evilColPosition--;
                }
                else
                {
                    evilRowPosition--;
                    evilColPosition--;
                }
            }
            return galaxy;
        }
    }
}
