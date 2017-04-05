using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Create_Person_Constructor
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

            public Person(string name) : this (name, 1)
            {
            }
            public Person(int age) : this ("No name", age)
            {
            }

            public Person() : this ("No name", 1)
            {  
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            Person p1;
            string name;
            int age;
            var input = Console.ReadLine();
            // Empty string or null
            if (String.IsNullOrEmpty(input))
            {
                p1 = new Person();
            }
            else
            {
                // Name,Age
                if (input.Contains(","))
                {
                    var inputArray = input.Split(',');
                    name = inputArray[0];
                    age = int.Parse(inputArray[1]);
                    p1 = new Person(name, age);
                }
                // Age
                else if (int.TryParse(input, out age))
                {
                    p1 = new Person(age);
                }
                // Name
                else
                {
                    name = input;
                    p1 = new Person(name);
                }
            }
            Console.WriteLine($"{p1.Name} {p1.Age}");
        }
    }
}