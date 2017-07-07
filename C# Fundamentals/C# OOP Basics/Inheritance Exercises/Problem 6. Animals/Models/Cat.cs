using System;

namespace Problem_6.Animals.Models
{
    class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
        protected override string ProduceSound()
        {
            return "MiauMiau";
        }
    }
}
