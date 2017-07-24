using System;
using System.Collections.Generic;
using Problem_8.Military_Elite.Interfaces;
using Problem_8.Military_Elite.Models;

namespace Problem_8.Military_Elite
{
    public class Startup
    {
        public static void Main()
        {
            var privates = new Dictionary<int, Private>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var soldierType = cmdArgs[0];
                int id;
                string firstName;
                string lastName;
                double salary;
                Corps corps;

                switch (soldierType)
                {
                    case "Private":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        var privateSoldier = new Private(id, firstName, lastName, salary);
                        privates.Add(id, privateSoldier);
                        Console.WriteLine(privateSoldier);
                        break;
                    case "LeutenantGeneral":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);
                        var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);

                        if (cmdArgs.Length >= 5)
                        {
                            for (var i = 5; i < cmdArgs.Length; i++)
                            {
                                var privateId = int.Parse(cmdArgs[i]);
                                privateSoldier = privates[privateId];

                                leutenantGeneral.Privates.Add(privateSoldier);
                            }
                        }
                        Console.WriteLine(leutenantGeneral);
                        break;
                    case "Engineer":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);

                            if (cmdArgs.Length >= 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    var repairPartName = cmdArgs[i];
                                    var repairHours = int.Parse(cmdArgs[i + 1]);

                                    var repair = new Repair(repairPartName, repairHours);
                                    engineer.Repairs.Add(repair);
                                }
                            }
                            Console.WriteLine(engineer);
                        }
                        break;
                    case "Commando":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = double.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);

                            if (cmdArgs.Length >= 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    if (Enum.TryParse(cmdArgs[i + 1], out MissionState missionState))
                                    {
                                        var missionName = cmdArgs[i];
                                        var mission = new Mission(missionName, missionState);
                                        commando.Missions.Add(mission);
                                    }
                                }
                                Console.WriteLine(commando);
                            }
                        }
                        break;
                    case "Spy":
                        id = int.Parse(cmdArgs[1]);
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        var codeNumber = int.Parse(cmdArgs[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;
                    default:
                        throw new ArgumentException("Invalid Type of Soldier!");
                }
            }
        }
    }
}
