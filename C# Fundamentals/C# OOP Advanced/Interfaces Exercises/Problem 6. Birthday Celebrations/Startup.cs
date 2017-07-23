using System;
using System.Collections.Generic;
using System.Linq;
using Problem_6.Birthday_Celebrations.Models;

namespace Problem_6.Birthday_Celebrations
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var citizens = new List<Citizen>();
            var pets = new List<Pet>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];

                string name;
                string id;
                string date;

                switch (command)
                {
                    case "Citizen":
                        name = cmdArgs[1];
                        var age = int.Parse(cmdArgs[2]);
                        id = cmdArgs[3];
                        date = cmdArgs[4];

                        var citizen = new Citizen(name, age, id, date);
                        citizens.Add(citizen);
                        break;
                    case "Pet":
                        name = cmdArgs[1];
                        date = cmdArgs[2];

                        var pet = new Pet(name, date);
                        pets.Add(pet);
                        break;
                }
            }
            var dateToSearch = Console.ReadLine();

            pets.Where(p => p.Date.EndsWith(dateToSearch))
                .Select(p => p.Date)
                .ToList()
                .ForEach(Console.WriteLine);

            citizens.Where(c => c.Date.EndsWith(dateToSearch))
                .Select(c => c.Date)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
