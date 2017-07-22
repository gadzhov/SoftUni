namespace Paw_Inc.Entities.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, int intelligenceCoefficient) 
            : base(name, age)
        {
            this.IntelligenceCoefficient = intelligenceCoefficient;
        }

        public int IntelligenceCoefficient { get; set; }
    }
}
