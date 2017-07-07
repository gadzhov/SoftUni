using System;

namespace Problem_6.Animals.Models
{
    class Tomcat : Animal
    {
        public Tomcat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
            base.Gender = Gender.Male;
        }

        protected override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}
