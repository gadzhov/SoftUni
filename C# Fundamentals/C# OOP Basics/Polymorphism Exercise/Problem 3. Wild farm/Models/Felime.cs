namespace Problem_3.Wild_farm.Models
{
    abstract class Felime : Mammal
    {
        protected Felime(string animalName, string animalType, double animalWeight,string livingRegion ) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
        }
    }
}
