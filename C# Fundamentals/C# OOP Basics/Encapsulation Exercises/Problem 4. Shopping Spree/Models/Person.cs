using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_4.Shopping_Spree.Models
{
    class Person
    {
        private string _name;
        private decimal _money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value) || value.Length == 0)
                {
                    throw new InvalidDataException("Name cannot be empty");
                }
                this._name = value;
            }
        }

        private decimal Money
        {
            get { return this._money; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("Money cannot be negative");
                }
                this._money = value;
            }
        }

        public List<Product> Products { get; }

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
            this.Money -= product.Cost;
            this.Products.Add(product);

            Printer.Print.WriteLine($"{this.Name} bought {product.Name}");
        }
    }
}
