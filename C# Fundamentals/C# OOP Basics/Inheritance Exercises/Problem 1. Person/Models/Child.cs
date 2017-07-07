using System;

namespace Problem_1.Person.Models
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        protected override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }
    }
}
