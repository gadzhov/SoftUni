using System;

namespace Problem_3.Wild_farm.Models
{
    class Tiger : Felime
    {
        public Tiger(string animalName, string animalType, double animalWeight, string livingRegion) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
                return;
            }
            base.Eat(food);
        }
    }
}
