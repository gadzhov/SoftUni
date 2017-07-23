using Problem_1.Define_an_Interface_IPerson.Entities.Interfaces;

namespace Problem_1.Define_an_Interface_IPerson.Entities
{
   public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
