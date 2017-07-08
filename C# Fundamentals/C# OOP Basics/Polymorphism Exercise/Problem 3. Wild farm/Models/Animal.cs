using System;

namespace Problem_3.Wild_farm.Models
{
    abstract class Animal
    {
        protected Animal(string animalName, string animalType, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
        }

        protected string AnimalName { get; set; }

        protected string AnimalType { get; set; }

        protected double AnimalWeight { get; set; }

        protected int FoodEaten { get; set; }

        public abstract void MakeSound();
        
        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public abstract override string ToString();
    }
}
