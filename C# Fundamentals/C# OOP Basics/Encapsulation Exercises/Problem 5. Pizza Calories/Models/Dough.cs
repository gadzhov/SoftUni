using System;

namespace Problem_5.Pizza_Calories.Models
{
    internal class Dough
    {
        private string _flourType;
        private string _bakingTechnique;
        private double _weight;
        private double _calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.Calories = this._calories;
        }

        private string FlourType
        {
            get => this._flourType;
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => this._bakingTechnique;
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._bakingTechnique = value;
            }
        }

        private double Weight
        {
            get => this._weight;
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this._weight = value;
            }
        }

        public double Calories
        {
            get => this._calories;
            private set
            {
                var flourModifier = 0.0;
                var bakingModifier = 0.0;

                switch (this.FlourType.ToLower())
                {
                    case "white":
                        flourModifier = 1.5;
                        break;
                    case "wholegrain":
                        flourModifier = 1.0;
                        break;
                }
                switch (this.BakingTechnique.ToLower())
                {
                    case "crispy":
                        bakingModifier = 0.9;
                        break;
                    case "chewy":
                        bakingModifier = 1.1;
                        break;
                    case "homemade":
                        bakingModifier = 1.0;
                        break;
                }

                this._calories = 2 * this.Weight * flourModifier * bakingModifier;
            }
        }

        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }
    }
}
