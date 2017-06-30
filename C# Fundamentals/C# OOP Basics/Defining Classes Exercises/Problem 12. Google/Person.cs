using System.Collections.Generic;

namespace Problem_12.Google
{
    public class Person
    {
        public Person()
        {
            this.Pokemons = new List<Pokemon>();
            this.Children = new List<Child>();
            this.Parents = new List<Parent>();
        }
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        //public override string ToString()
        //{
//            return $@"{this.Name}
//Company:
//{(this.Company != null ? $"{this.Company.Name} {this.Company.Departament} {this.Company.Salary:F2}" : string.Empty)}
//Car:{this.Car.Model} {this.Car.Speed}
//Pokemon:
//{this.Pokemons}
//Parents:
//{this.Parents}
//Children:
//{this.Children}";
        //}
    }
}
