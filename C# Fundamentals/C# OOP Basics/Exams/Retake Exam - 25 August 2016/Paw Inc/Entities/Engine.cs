using System;
using System.Collections.Generic;
using System.Linq;
using Paw_Inc.Entities.Animals;
using Paw_Inc.Entities.Centers;

namespace Paw_Inc.Entities
{
    public class Engine
    {
        private Dictionary<string, CleansingCenter> cleansingCenters;
        private Dictionary<string, AdoptionCenter> adoptionCenters;
        private List<Animal> adoptetAnimals;
        private Dictionary<string, CastrationCenter> castrationCenters;
        private List<Animal> castratedAnimals;

        public Engine()
        {
            this.adoptionCenters = new Dictionary<string, AdoptionCenter>();
            this.cleansingCenters = new Dictionary<string, CleansingCenter>();
            this.adoptetAnimals = new List<Animal>();
            this.castrationCenters = new Dictionary<string, CastrationCenter>();
            this.castratedAnimals = new List<Animal>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "Paw Paw Pawah")
            {
                var cmdArgs = input
                    .Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];
                string name;
                int age;
                string adoptionCenterName;
                string cleansingCenterName;
                string castrationCenterName;
                switch (command)
                {
                    case "RegisterCleansingCenter":
                        //•	RegisterCleansingCenter | {name}
                        name = cmdArgs[1];
                        var cleaningCenter = new CleansingCenter(name);

                        this.cleansingCenters.Add(name, cleaningCenter);
                        break;
                    case "RegisterAdoptionCenter":
                        //•	RegisterAdoptionCenter | {name}
                        name = cmdArgs[1];
                        var adoptionCenter = new AdoptionCenter(name);

                        this.adoptionCenters.Add(name, adoptionCenter);
                        break;
                    case "RegisterDog":
                        //•	RegisterDog | {name} | {age} | {learnedCommands} | {adoptionCenterName}
                        name = cmdArgs[1];
                        age = int.Parse(cmdArgs[2]);
                        var learnedCommands = int.Parse(cmdArgs[3]);
                        adoptionCenterName = cmdArgs[4];
                        var dog = new Dog(name, age, learnedCommands);

                        this.adoptionCenters[adoptionCenterName].RegisterAnimal(dog);
                        break;
                    case "RegisterCat":
                        //•	RegisterCat | {name} | {age| | {intelligenceCoefficient} | {adoptionCenterName}
                        name = cmdArgs[1];
                        age = int.Parse(cmdArgs[2]);
                        var intelligenceCoefficient = int.Parse(cmdArgs[3]);
                        adoptionCenterName = cmdArgs[4];
                        var cat = new Cat(name, age, intelligenceCoefficient);

                        this.adoptionCenters[adoptionCenterName].RegisterAnimal(cat);
                        break;
                    case "SendForCleansing":
                        //•	SendForCleansing | {adoptionCenterName} | {cleansingCenterName}
                        adoptionCenterName = cmdArgs[1];
                        cleansingCenterName = cmdArgs[2];

                        var animalsForClean = this.adoptionCenters[adoptionCenterName].GetForClean();
                        this.cleansingCenters[cleansingCenterName].GetAnimalsForCleansing(adoptionCenterName, animalsForClean);
                        break;
                    case "Cleanse":
                        //•	Cleanse | {cleansingCenterName}
                        cleansingCenterName = cmdArgs[1];
                        var cleanedAnimals = this.cleansingCenters[cleansingCenterName].CleanAnimals();

                        foreach (var animal in cleanedAnimals)
                        {
                            this.adoptionCenters[animal.Key].GetFromCleaningCenter(animal.Value);
                        }
                        break;
                    case "Adopt":
                        //•	Adopt | {adoptionCenterName}
                        adoptionCenterName = cmdArgs[1];
                        this.adoptetAnimals.AddRange(this.adoptionCenters[adoptionCenterName].Adopt());
                        break;
                    case "RegisterCastrationCenter":
                        //•	RegisterCastrationCenter | {name}
                        castrationCenterName = cmdArgs[1];
                        var castrationCenter = new CastrationCenter(castrationCenterName);
                        this.castrationCenters.Add(castrationCenterName, castrationCenter);
                        break;
                    case "SendForCastration":
                        //•	SendForCastration | {adoptionCenterName} | {castrationCenterName}
                        adoptionCenterName = cmdArgs[1];
                        castrationCenterName = cmdArgs[2];

                        var animalsForCastration = this.adoptionCenters[adoptionCenterName].GetForCastration();
                        this.castrationCenters[castrationCenterName].GetForCastration(adoptionCenterName, animalsForCastration);
                        break;
                    case "Castrate":
                        //•	Castrate | {castrationCenterName}
                        castrationCenterName = cmdArgs[1];
                        var animalsToGoHome = this.castrationCenters[castrationCenterName].Castrate();

                        foreach (var center in animalsToGoHome)
                        {
                            this.adoptionCenters[center.Key].GetFromCleaningCenter(center.Value);
                            this.castratedAnimals.AddRange(center.Value);
                        }
                        break;
                    case "CastrationStatistics":
                        //•	CastrationStatistics
                        var castrationCentersCount = 0;
                        foreach (var center in this.castrationCenters.Values)
                        {
                            castrationCentersCount = center.Animals.Values.Count;
                        }
                        Console.WriteLine("Paw Inc. Regular Castration Statistics");
                        Console.WriteLine($"Castration Centers: {castrationCentersCount}");
                        Console.WriteLine($"Castrated Animals: {(this.castratedAnimals.Count > 0 ? string.Join(", ", this.castratedAnimals.OrderBy(a => a.Name)) : "None")}");
                        break;
                }
            }
            var aCenter = this.adoptionCenters.Values;
            List<Animal> cleansedAnimals = null;
            foreach (var center in aCenter)
            {
                var tmp = center.Animals.Values;
                foreach (var a in tmp)
                {
                    cleansedAnimals = a.Where(an => an.IsClean).ToList();
                }
            }
            cleansedAnimals.AddRange(this.adoptetAnimals);

            var animalsWaitingForAdption = new List<Animal>();

            foreach (var adoptionCenter in this.adoptionCenters.Values)
            {
                foreach (var animal in adoptionCenter.Animals)
                {
                    animalsWaitingForAdption.AddRange(animal.Value.Where(a => a.IsClean));
                }
            }

            var animalsAwaitingForClean = this.cleansingCenters.Values.Sum(c => c.Animals.Values.Sum(a => a.Count));

            Console.WriteLine("Paw Incorporative Regular Statistics");
            Console.WriteLine($"Adoption Centers: {this.adoptionCenters.Count}");
            Console.WriteLine($"Cleansing Centers: {this.cleansingCenters.Count}");
            Console.WriteLine($"Adopted Animals: {(this.adoptetAnimals.Count > 0 ? string.Join(", ", this.adoptetAnimals.OrderBy(a => a.Name)) : "None")}");
            Console.WriteLine($"Cleansed Animals: {(cleansedAnimals.Count > 0 ? string.Join(", ", cleansedAnimals.OrderBy(a => a.Name)) : "None")}");
            Console.WriteLine($"Animals Awaiting Adoption: {animalsWaitingForAdption.Count}");
            Console.WriteLine($"Animals Awaiting Cleansing: {animalsAwaitingForClean}");
        }
    }
}
