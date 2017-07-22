using System;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "Quit")
        {
            var cmdArgs = input
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = cmdArgs[0];

            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(cmdArgs);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(cmdArgs);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(cmdArgs[1]));
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(cmdArgs[1]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Command Type!");
            }
        }
        Console.WriteLine(this.nationsBuilder.GetWarsRecord());
    }
}
