using System.IO;

namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string _name;
        private int _age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new InvalidDataException("Name cannot be empty.");
                }
                this._name = value;
            }
        }

        public int Age
        {
            get
            {
                return this._age;
            }

            internal set
            {
                if (value < 0 || value > 15)
                {
                    throw new InvalidDataException("Age should be between 0 and 15.");
                }
               this._age = value;
            }
        }

        public double GetProductPerDay()
        {
            return this.CalculateProductPerDay();
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
