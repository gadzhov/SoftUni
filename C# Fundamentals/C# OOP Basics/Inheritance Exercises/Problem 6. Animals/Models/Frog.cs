using System;

namespace Problem_6.Animals.Models
{
    class Frog : Animal
    {
        public Frog(string name, int age, Gender gender)
            : base (name, age, gender)
        {
        }

        protected override string ProduceSound()
        {
            return "Frogggg";
        }
    }
}
