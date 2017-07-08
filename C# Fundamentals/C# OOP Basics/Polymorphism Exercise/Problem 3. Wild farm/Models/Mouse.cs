using System;

namespace Problem_3.Wild_farm.Models
{
    class Mouse : Mammal
    {
        public Mouse(string animalName, string animalType, double animalWeight, string livingRegion) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Console.WriteLine("Mouses are not eating that type of food!");
                return;
            }
            base.Eat(food);
        }
    }
}
