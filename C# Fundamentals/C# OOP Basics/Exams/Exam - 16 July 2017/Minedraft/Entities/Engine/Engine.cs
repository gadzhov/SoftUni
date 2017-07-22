using System;
using System.Linq;

public class Engine
{
    private readonly DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }
    public void Run()
    {
        try
        {
            string input;

            while ((input = Console.ReadLine()) != "Shutdown")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = cmdArgs[0];

                cmdArgs.RemoveAt(0);
                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(this.draftManager.RegisterHarvester(cmdArgs));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(this.draftManager.RegisterProvider(cmdArgs));
                        break;
                    case "Day":
                        Console.WriteLine(this.draftManager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(this.draftManager.Mode(cmdArgs));
                        break;
                    case "Check":
                        Console.WriteLine(this.draftManager.Check(cmdArgs));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            Console.WriteLine(this.draftManager.ShutDown());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
