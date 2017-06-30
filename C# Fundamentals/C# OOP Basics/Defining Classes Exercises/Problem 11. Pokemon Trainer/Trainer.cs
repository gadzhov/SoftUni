using System.Collections.Generic;

namespace Problem_11.Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer()
        {
            this.Pokemons = new List<Pokemon>();
            this.NumberOfBadges = 0;
        }
        // name, number of badges and a collection of pokemon
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
