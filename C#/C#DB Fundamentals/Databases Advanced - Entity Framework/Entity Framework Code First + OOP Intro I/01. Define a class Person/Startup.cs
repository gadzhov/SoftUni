using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Define_a_class_Person
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

            public Person()
            {
                Name = "Default";
                Age = 1;
            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            var p1 = new Person("Pesho", 20);
            var p2 = new Person("Gosho", 18);
            var p3 = new Person("Stamat", 43);
            var p4 = new Person();
        }
    }
}
