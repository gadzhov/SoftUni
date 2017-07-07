using System;
using System.Text;

namespace Problem_1.Person.Models
{
    public class Person
    {
        private string _name;
        private int _age;

        protected Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string Name
        {
            get => this._name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }
                this._name = value;
            }
        }

        protected virtual int Age
        {
            get => this._age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                this._age = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString();
        }
    }
}
