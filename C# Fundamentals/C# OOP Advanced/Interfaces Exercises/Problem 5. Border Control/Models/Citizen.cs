using Problem_5.Border_Control.Interfaces;

namespace Problem_5.Border_Control.Models
{
    public class Citizen : ICitizen, ITracking
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}
