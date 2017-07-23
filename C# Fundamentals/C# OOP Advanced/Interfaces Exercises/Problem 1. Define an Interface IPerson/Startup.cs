using System;
using System.Reflection;
using Problem_1.Define_an_Interface_IPerson.Entities;
using Problem_1.Define_an_Interface_IPerson.Entities.Interfaces;

namespace Problem_1.Define_an_Interface_IPerson
{
    public class Startup
    {
        public static void Main()
        {
            var personInterface = typeof(Citizen).GetInterface("IPerson");
            var properties = personInterface.GetProperties();
            Console.WriteLine(properties.Length);
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
