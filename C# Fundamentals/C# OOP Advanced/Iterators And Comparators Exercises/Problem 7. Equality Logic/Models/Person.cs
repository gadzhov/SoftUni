using System;

namespace Problem_7.Equality_Logic.Models
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            var otherPerson = (Person) obj;

            return otherPerson != null && this.Name == otherPerson.Name && this.Age == otherPerson.Age;
        }

        public override int GetHashCode()
        {
            return (this.Name + this.Age).GetHashCode();
        }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
