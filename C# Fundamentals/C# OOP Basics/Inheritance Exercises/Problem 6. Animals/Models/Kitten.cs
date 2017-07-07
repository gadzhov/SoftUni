using System;

namespace Problem_6.Animals.Models
{
    class Kitten : Animal
    {
        public Kitten(string name, int age, Gender gender)
            : base(name, age, gender)
        {
            base.Gender = Gender.Female;
        }

        protected override string ProduceSound()
        {
            return "Miau";
        }
    }
}
