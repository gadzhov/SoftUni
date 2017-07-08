using System;

namespace Problem_3.Wild_farm.Models
{
    class Cat : Felime
    {
        public Cat(string animalName, string animalType, double animalWeight,string livingRegion, string breed) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
            this.Breed = breed;
        }

        private string Breed { get; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{base.AnimalType}[{base.AnimalName}, {this.Breed}, {base.AnimalWeight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
