using System;
using System.Text;

namespace Problem_2.Book_Shop.Models
{
    public class Book
    {
        private string _title;
        private string _author;
        private decimal _price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        private string Title
        {
            get => this._title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this._title = value;
            }
        }

        private string Author
        {
            get => this._author;
            set
            {
                var splitedNames = value.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (splitedNames.Length > 1)
                {
                    var secondName = splitedNames[1];
                    if (char.IsDigit(secondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                
                this._author = value;
            }
        }

        protected virtual decimal Price
        {
            get => this._price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this._price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(this.Title)
                .Append("Author: ").AppendLine(this.Author)
                .Append("Price: ").Append($"{this.Price:f1}")
                .AppendLine();

            return sb.ToString();
        }
    }
}
