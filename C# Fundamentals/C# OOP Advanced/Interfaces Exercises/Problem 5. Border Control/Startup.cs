using System;
using System.Collections.Generic;
using System.Linq;
using Problem_5.Border_Control.Interfaces;
using Problem_5.Border_Control.Models;

namespace Problem_5.Border_Control
{
    public class Startup
    {
        private static void Main()
        {
            var citizens = new List<Citizen>();
            var robots = new List<Robot>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 3)
                {
                    var name = cmdArgs[0];
                    var age = int.Parse(cmdArgs[1]);
                    var id = cmdArgs[2];

                    var citizen = new Citizen(name, age, id);
                    citizens.Add(citizen);
                }
                else
                {
                    var model = cmdArgs[0];
                    var id = cmdArgs[1];

                    var robot = new Robot(model, id);
                    robots.Add(robot);
                }
            }
            var fakeIds = Console.ReadLine();

            robots.Where(r => r.Id.EndsWith(fakeIds))
                .Select(r => r.Id)
                .ToList()
                .ForEach(Console.WriteLine);
            citizens.Where(c => c.Id.EndsWith(fakeIds))
                .Select(c => c.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
