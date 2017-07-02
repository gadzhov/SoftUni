using System;
using System.Collections.Generic;
using Problem_6.Football_Team_Generator.Models;

namespace Problem_6.Football_Team_Generator
{
    class Startup
    {
        static void Main()
        {
            string input;
            var  teams = new Dictionary<string, Team>();
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var inputArgs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (inputArgs[0] == "Team")
                    {
                        teams.Add(inputArgs[1], new Team(inputArgs[1]));
                    }
                    else if (inputArgs[0] == "Add")
                    {
                        if (teams.ContainsKey(inputArgs[1]))
                        {
                            var player = new Player(inputArgs[2], int.Parse(inputArgs[3]), int.Parse(inputArgs[4]), int.Parse(inputArgs[5]), int.Parse(inputArgs[6]), int.Parse(inputArgs[7]));
                            teams[inputArgs[1]].AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {inputArgs[1]} does not exist.");
                        }
                    }
                    else if (inputArgs[0] == "Remove")
                    {
                        var playerName = inputArgs[2];
                        teams[inputArgs[1]].RemovePlayer(playerName);
                    }
                    else if (inputArgs[0] == "Rating")
                    {
                        if (teams.ContainsKey(inputArgs[1]))
                        {
                            Console.WriteLine($"{teams[inputArgs[1]].Name} - {teams[inputArgs[1]].Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {inputArgs[1]} does not exist.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
