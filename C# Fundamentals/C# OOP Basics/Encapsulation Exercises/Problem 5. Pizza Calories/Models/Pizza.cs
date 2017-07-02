using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5.Pizza_Calories.Models
{
    class Pizza
    {
        private string _name;
        private double _calories;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        private string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this._name = value;
            }
        }

        private List<Topping> Toppings { get; }

        public Dough Dough { get; set; }

        private double Calories
        {
            get => this._calories;
            set { this._calories = this.Dough.Calories + this.Toppings.Sum(t => t.Calories); }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
            this.Calories = this._calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}
