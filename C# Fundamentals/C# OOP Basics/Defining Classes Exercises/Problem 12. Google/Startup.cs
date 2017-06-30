using System;
using System.Collections.Generic;
using System.Globalization;

namespace Problem_12.Google
{
    // 60/100 I thing exact parsing gone wrong
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            var people = new Dictionary<string, Person>();
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = inputArgs[0];
                var command = inputArgs[1];
                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Person
                    {
                        Name = name
                    });
                }
                switch (command)
                {
                    case "company":
                        var companyName = inputArgs[2];
                        var companyDepartment = inputArgs[3];
                        var companySalary = decimal.Parse(inputArgs[4]);
                        var company = new Company
                        {
                            Name = companyName,
                            Departament = companyDepartment,
                            Salary = companySalary
                        };
                        people[name].Company = company;
                        break;
                    case "car":
                        var carModel = inputArgs[2];
                        var carSpeed = int.Parse(inputArgs[3]);
                        var car = new Car
                        {
                            Model = carModel,
                            Speed = carSpeed
                        };
                        people[name].Car = car;
                        break;
                    case "pokemon":
                        var pokomenName = inputArgs[2];
                        var pokemonType = inputArgs[3];
                        var pokemon = new Pokemon
                        {
                            Name = pokomenName,
                            Type = pokemonType
                        };
                        people[name].Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        var parentName = inputArgs[2];
                        var parentBirthDate = DateTime.ParseExact(inputArgs[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var parent = new Parent
                        {
                            Name = parentName,
                            BirthDate = parentBirthDate
                        };
                        people[name].Parents.Add(parent);
                        break;
                    case "children":
                        var childName = inputArgs[2];
                        var childBirthDate = DateTime.ParseExact(inputArgs[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var child = new Child
                        {
                            Name = childName,
                            BirthDay = childBirthDate
                        };
                        people[name].Children.Add(child);
                        break;
                }
            }
            var nameToPrint = Console.ReadLine();
            var person = people[nameToPrint];
            Console.WriteLine($@"{person.Name}");
            Console.WriteLine("Company:");
            if (person.Company != null)
            {
                Console.WriteLine($"{person.Company.Name} {person.Company.Departament} {person.Company.Salary:F2}");
            }
            Console.WriteLine("Car:");
            if (person.Car != null)
            {
                Console.WriteLine($"{person.Car.Model} {person.Car.Speed}");
            }
            Console.WriteLine("Pokemon:");
            foreach (var pokemon in person.Pokemons)
            {
                Console.Write($"{pokemon.Name} {pokemon.Type}");
                Console.WriteLine();
            }
            Console.WriteLine("Parents:");
            foreach (var parent in person.Parents)
            {
                Console.Write($"{parent.Name} {parent.BirthDate:dd/MM/yyyy}");
                Console.WriteLine();
            }
            Console.WriteLine("Children:");
            foreach (var child in person.Children)
            {
                Console.Write($"{child.Name} {child.BirthDay:dd/MM/yyyy}");
                Console.WriteLine();
            }
        }
    }
}
