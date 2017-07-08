using System;

namespace Problem_3.Wild_farm.Models
{
    class Zebra : Mammal
    {
        public Zebra(string animalName, string animalType, double animalWeight, string livingRegion) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Console.WriteLine("Zebras are not eating that type of food!");
                return;
            }
            base.Eat(food);
        }
    }
}
