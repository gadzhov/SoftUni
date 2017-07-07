using System;
using Problem_6.Animals.Models;

namespace Problem_6.Animals
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var animal = input;
                var animalArgs = Console.ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = animalArgs[0];
                var age = int.Parse(animalArgs[1]);
                Gender gender = Gender.None;
                Enum.TryParse(animalArgs[2], out gender);

                try
                {
                    switch (animal.ToLower())
                    {
                        case "dog":
                            var dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "cat":
                            var cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "frog":
                            var frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "kitten":
                            var kitten = new Kitten(name, age, gender);
                            Console.WriteLine(kitten);
                            break;
                        case "tomcat":
                            var tomcat = new Tomcat(name, age, gender);
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
