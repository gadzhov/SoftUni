namespace Problem_3.Wild_farm.Models
{
    abstract class Mammal : Animal
    {
        protected Mammal(string animalName, string animalType, double animalWeight, string livingRegion) 
            : base(animalName, animalType, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.AnimalType}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {FoodEaten}]";
        }
    }
}
