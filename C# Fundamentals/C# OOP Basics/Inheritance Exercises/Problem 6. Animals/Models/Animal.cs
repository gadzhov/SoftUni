using System;
using System.Text;

namespace Problem_6.Animals.Models
{
    internal enum Gender
    {
        None,
        Male,
        Female
    }

    internal abstract class Animal
    {
        private string _name;
        private int _age;
        private Gender _gender;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        private string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this._name = value;
            }
        }

        private int Age
        {
            get => this._age;
            set
            {
                if (value < 0 || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this._age = value;
            }
        }

        protected Gender Gender
        {
            get => this._gender;
            set
            {
                if (value == Gender.None)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this._gender = value;
            }
        }

        protected abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetType().Name)
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .Append(this.ProduceSound());

            return sb.ToString();
        }
    }
}
