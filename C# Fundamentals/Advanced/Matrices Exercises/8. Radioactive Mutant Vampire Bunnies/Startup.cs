using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _8.Radioactive_Mutant_Vampire_Bunnies
{
    class Startup
    {
        static void Main(string[] args)
        {
            var lairDimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var lair = new char[lairDimensions[0]][];
            lair = FillLair(lairDimensions[1], lair);
            var commands = Console.ReadLine();
            var result = new Dictionary<string, bool>();
            result.Add("gameOver", false);
            result.Add("isAlive", true);

            lair = ExecuteCommands(commands, lair, result);

            foreach (var l in lair)
            {
                Console.WriteLine(string.Join("", l));
            }
            if (result["isAlive"])
            {
                Console.Write("won: ");
            }
            else
            {
                Console.Write("dead: ");
            }
            Console.WriteLine(result.Keys.Last());
        }

        private static char[][] ExecuteCommands(string commands, char[][] lair, Dictionary<string, bool> result)
        {
            

            for (int i = 0; i < commands.Length; i++)
            {
                var c = commands[i];

                switch (c)
                {
                    case 'U':
                        result = MovePlayerUp(lair, result);
                        break;
                    case 'D':
                        result = MovePlayerDown(lair, result);
                        break;
                    case 'L':
                        result = MovePlayerLeft(lair, result);
                        break;
                    case 'R':
                        result = MovePlayerRight(lair, result);
                        break;
                }
                BunniesSpread(lair, result);

                if (result["gameOver"])
                {
                    break;
                }
            }

            return lair;
        }

        private static void BunniesSpread(char[][] lair, Dictionary<string, bool> result)
        {
            var buniesPositions = new List<int[]>();
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    if (lair[rowIndex][colIndex] == 'B')
                    {
                        buniesPositions.Add(new[] { rowIndex, colIndex });
                    }
                }
            }
            foreach (var position in buniesPositions)
            {
                var rowIndex = position[0];
                var colIndex = position[1];

                BunniesTrySpread(lair, rowIndex - 1, colIndex, result);
                BunniesTrySpread(lair, rowIndex + 1, colIndex, result);
                BunniesTrySpread(lair, rowIndex, colIndex - 1, result);
                BunniesTrySpread(lair, rowIndex, colIndex + 1, result);
            }
        }

        private static void BunniesTrySpread(char[][] lair, int rowIndex, int colIndex, Dictionary<string, bool> result)
        {
            try
            {
                if (lair[rowIndex][colIndex] != 'P')
                {
                    lair[rowIndex][colIndex] = 'B';
                }
                else
                {
                    result.Add(rowIndex + " " + colIndex, true);
                    result["gameOver"] = true;
                    result["isAlive"] = false;
                    lair[rowIndex][colIndex] = 'B';
                }
            }
            catch
            {
                // ignored
            }
        }

        private static Dictionary<string, bool> MovePlayerRight(char[][] lair, Dictionary<string, bool> result)
        {
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    if (lair[rowIndex][colIndex] == 'P')
                    {
                        if (colIndex == lair[rowIndex].Length - 1)
                        {
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + " " + colIndex, true);
                            return result;
                        }
                        if (lair[rowIndex][colIndex + 1] == 'B')
                        {
                            result["isAlive"] = false;
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + " " + (colIndex + 1), true);
                        }
                        else
                        {
                            lair[rowIndex][colIndex] = '.';
                            lair[rowIndex][colIndex + 1] = 'P';
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, bool> MovePlayerLeft(char[][] lair, Dictionary<string, bool> result)
        {
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    if (lair[rowIndex][colIndex] == 'P')
                    {
                        if (colIndex == 0)
                        {
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + " " + colIndex, true);
                            return result;
                        }
                        if (lair[rowIndex][colIndex - 1] == 'B')
                        {
                            result["isAlive"] = false;
                            result["gameOver"] = true;
                            result.Add(rowIndex + " " + (colIndex - 1), true);
                            lair[rowIndex][colIndex] = '.';
                        }
                        else
                        {
                            lair[rowIndex][colIndex] = '.';
                            lair[rowIndex][colIndex - 1] = 'P';
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, bool> MovePlayerDown(char[][] lair, Dictionary<string, bool> result)
        {
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    if (lair[rowIndex][colIndex] == 'P')
                    {
                        if (rowIndex == lair.Length - 1)
                        {
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + " " + colIndex, true);
                            return result;
                        }
                        if (lair[rowIndex + 1][colIndex] == 'B')
                        {
                            result["isAlive"] = false;
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + 1 + " " + colIndex, true);
                        }
                        else
                        {
                            lair[rowIndex][colIndex] = '.';
                            lair[rowIndex + 1][colIndex] = 'P';
                            return result; // this solution or reverse loop
                        }
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, bool> MovePlayerUp(char[][] lair, Dictionary<string, bool> result)
        {
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    if (lair[rowIndex][colIndex] == 'P')
                    {
                        if (rowIndex == 0)
                        {
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex + " " + colIndex, true);
                            return result;
                        }
                        if (lair[rowIndex - 1][colIndex] == 'B')
                        {
                            result["isAlive"] = false;
                            result["gameOver"] = true;
                            lair[rowIndex][colIndex] = '.';
                            result.Add(rowIndex -1 + " " + colIndex, true);
                            return result;
                        }
                        else
                        {
                            lair[rowIndex][colIndex] = '.';
                            lair[rowIndex - 1][colIndex] = 'P';
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        private static char[][] FillLair(int colLength, char[][] lair)
        {
            for (int rowIndex = 0; rowIndex < lair.Length; rowIndex++)
            {
                lair[rowIndex] = new char[colLength];
                var inputLine = Console.ReadLine();
                for (int colIndex = 0; colIndex < lair[rowIndex].Length; colIndex++)
                {
                    lair[rowIndex][colIndex] = inputLine[colIndex];
                }
            }

            return lair;
        }
    }
}
