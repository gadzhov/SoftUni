using System;
using System.Collections.Generic;
using System.Linq;
using Problem_7.Food_Shortage.Models;

namespace Problem_7.Food_Shortage
{
    public class Startup
    {
        public static void Main()
        {
            var citizens = new Dictionary<string, Citizen>();
            var rebels = new Dictionary<string, Rebel>();

            var nLines = int.Parse(Console.ReadLine());
            string input;
            string name;
            int age;

            for (var i = 0; i < nLines; i++)
            {
                input = Console.ReadLine();
                var cmdArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length == 4)
                {
                    name = cmdArgs[0];
                    age = int.Parse(cmdArgs[1]);
                    var id = cmdArgs[2];
                    var date = cmdArgs[3];

                    var citizen = new Citizen(name, age, id, date);
                    citizens.Add(name, citizen);
                }
                else
                {
                    name = cmdArgs[0];
                    age = int.Parse(cmdArgs[1]);
                    var group = cmdArgs[2];

                    var rebel = new Rebel(name, age, group);
                    rebels.Add(name, rebel);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                if (citizens.ContainsKey(input))
                {
                    citizens[input].BuyFood();
                }
                else if (rebels.ContainsKey(input))
                {
                    rebels[input].BuyFood();
                }
            }
            Console.WriteLine(citizens.Sum(c => c.Value.Food) + rebels.Sum(r => r.Value.Food));
        }
    }
}
