using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Oldest_Family_Member
{
    class Startup
    {
        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Family
        {
            public List<Person> Persons { get; set; }

            public Family()
            {
                this.Persons = new List<Person>();
            }
            public void AddMember(Person member)
            {
                this.Persons.Add(member);
            }

            public Person GetOldestMember()
            {
                var pMax = Persons.OrderByDescending(p => p.Age).FirstOrDefault();
                return pMax;
            }
        }
        static void Main(string[] args)
        {
            var family = new Family();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                family.AddMember(person);
            }
            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
