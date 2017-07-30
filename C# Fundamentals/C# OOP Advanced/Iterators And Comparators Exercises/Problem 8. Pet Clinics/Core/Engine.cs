using System;
using System.Collections.Generic;
using System.Linq;
using Problem_8.Pet_Clinics.Models;

namespace Problem_8.Pet_Clinics.Core
{
    public class Engine
    {
        private IList<Pet> allPets;
        private IList<Clinic> clinics;

        public Engine()
        {
            this.allPets = new List<Pet>();
            this.clinics = new List<Clinic>();
        }

        public void Run()
        {
            var input = string.Empty;

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                try
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = tokens[0];
                    tokens.RemoveAt(0);

                    switch (command)
                    {
                        case "Create":
                            if (tokens[0] == "Pet")
                            {
                                this.allPets.Add(new Pet(tokens[1], int.Parse(tokens[2]), tokens[3]));
                            }
                            else if (tokens[0] == "Clinic")
                            {
                                this.clinics.Add(new Clinic(tokens[1], int.Parse(tokens[2])));
                            }
                            break;

                        case "Add":
                            Console.WriteLine(this.clinics.First(c => c.Name == tokens[1]).Add(this.allPets.First(p => p.Name == tokens[0])));
                            break;

                        case "Release":
                            Console.WriteLine(this.clinics.First(c => c.Name == tokens[0]).Release());
                            break;

                        case "HasEmptyRooms":
                            Console.WriteLine(this.clinics.First(c => c.Name == tokens[0]).HasEmptyRooms());
                            break;

                        case "Print":
                            if (tokens.Count == 1)
                            {
                                this.clinics.First(c => c.Name == tokens[0]).Print();
                            }
                            else if (tokens.Count > 1)
                            {
                                this.clinics.First(c => c.Name == tokens[0]).Print(int.Parse(tokens[1]));
                            }
                            break;

                        default:
                            throw new InvalidOperationException("Invalid Operation!");
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}