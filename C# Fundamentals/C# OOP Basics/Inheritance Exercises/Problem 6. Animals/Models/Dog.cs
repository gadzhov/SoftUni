using System;

namespace Problem_6.Animals.Models
{
    class Dog : Animal
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
        protected override string ProduceSound()
        {
            return "BauBau";
        }
    }
}
