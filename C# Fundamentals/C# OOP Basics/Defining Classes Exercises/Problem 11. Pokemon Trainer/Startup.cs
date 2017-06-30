using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11.Pokemon_Trainer
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            var trainers = new Dictionary<string, Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // “<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>”
                var trainerName = inputArgs[0];
                var pokemonName = inputArgs[1];
                var pokemonElement = inputArgs[2];
                var pokemonHealth = int.Parse(inputArgs[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer
                    {
                        Name = trainerName,
                        Pokemons = new List<Pokemon>
                        {
                            new Pokemon
                            {
                                Name = pokemonName,
                                Element = pokemonElement,
                                Health = pokemonHealth
                            }
                        }
                    });
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(new Pokemon
                    {
                        Name = pokemonName,
                        Element = pokemonElement,
                        Health = pokemonHealth
                    });
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var element = input;

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        for (var i = 0; i < trainer.Value.Pokemons.Count; i++)
                        {
                            trainer.Value.Pokemons[i].Health -= 10;
                            if (trainer.Value.Pokemons[i].Health <= 0)
                            {
                                trainer.Value.Pokemons.Remove(trainer.Value.Pokemons[i]);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
