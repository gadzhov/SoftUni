using System;

namespace Problem_5.Pizza_Calories.Models
{
    class Topping
    {
        private string _type;
        private double _weight;
        private double _calories;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
            this.Calories = _calories;
        }

        private string Type
        {
            get => this._type;
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this._type = value;
            }
        }

        private double Weight
        {
            get => this._weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this._weight = value;
            }
        }

        public double Calories
        {
            get => this._calories;
            private set
            {
                var typeModifier = 0.0;
                switch (this.Type.ToLower())
                {
                    case "meat":
                        typeModifier = 1.2;
                        break;
                    case "veggies":
                        typeModifier = 0.8;
                        break;
                    case "cheese":
                        typeModifier = 1.1;
                        break;
                    case "sauce":
                        typeModifier = 0.9;
                        break;
                }
                this._calories = 2 * this.Weight * typeModifier;
            }
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
