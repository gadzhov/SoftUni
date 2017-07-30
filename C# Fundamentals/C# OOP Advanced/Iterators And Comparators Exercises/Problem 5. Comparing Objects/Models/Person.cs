using System;

namespace Problem_5.Comparing_Objects.Models
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        private string Name { get; }

        private int Age { get; }

        private string Town { get; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);

                if (result == 0)
                {
                    result = this.Town.CompareTo(other.Town);
                }
            }

            return result;
        }
    }
}
