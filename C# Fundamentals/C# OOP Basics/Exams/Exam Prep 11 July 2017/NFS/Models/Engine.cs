using System;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Start()
    {
        string input;

        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            var cmdArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var command = cmdArgs[0];
            int id;
            string type;
            int raceId;
            int carId;
            try
            {
                switch (command)
                {
                    case "register":
                        // register {id} {type} {brand} {model} {year} {horsepower} {acceleration} {suspension} {durability}
                        id = int.Parse(cmdArgs[1]);
                        type = cmdArgs[2];
                        var brand = cmdArgs[3];
                        var model = cmdArgs[4];
                        var yearOfProduction = int.Parse(cmdArgs[5]);
                        var horsepower = int.Parse(cmdArgs[6]);
                        var acceleration = int.Parse(cmdArgs[7]);
                        var suspension = int.Parse(cmdArgs[8]);
                        var durability = int.Parse(cmdArgs[9]);

                        this.carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                        break;
                    case "check":
                        // check {id}
                        id = int.Parse(cmdArgs[1]);
                        var check = this.carManager.Check(id);
                        Console.WriteLine(check);
                        break;
                    case "open":
                        // open {id} {type} {length} {route} {prizePool}
                        id = int.Parse(cmdArgs[1]);
                        type = cmdArgs[2];
                        var length = int.Parse(cmdArgs[3]);
                        var route = cmdArgs[4];
                        var prizePool = int.Parse(cmdArgs[5]);

                        if (cmdArgs.Length == 7)
                        {
                            var specialProp = int.Parse(cmdArgs[6]);
                            this.carManager.OpenSpeacial(id, type, length, route, prizePool, specialProp);
                        }
                        else
                        {
                            this.carManager.Open(id, type, length, route, prizePool);
                        }

                        break;
                    case "participate":
                        // participate {carId} {raceId}
                        carId = int.Parse(cmdArgs[1]);
                        raceId = int.Parse(cmdArgs[2]);

                        this.carManager.Participate(carId, raceId);
                        break;
                    case "start":
                        // start {raceId}
                        raceId = int.Parse(cmdArgs[1]);

                        var result = this.carManager.Start(raceId);
                        Console.WriteLine(result);
                        break;
                    case "park":
                        // park {carId}
                        carId = int.Parse(cmdArgs[1]);

                        this.carManager.Park(carId);
                        break;
                    case "unpark":
                        // unpark {carId}
                        carId = int.Parse(cmdArgs[1]);

                        this.carManager.Unpark(carId);
                        break;
                    case "tune":
                        // tune {tuneIndex} {tuneAddOn}
                        var tuneIndex = int.Parse(cmdArgs[1]);
                        var tuneAddon = cmdArgs[2];

                        this.carManager.Tune(tuneIndex, tuneAddon);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
