using Problem_6.Birthday_Celebrations.Interfaces;

namespace Problem_6.Birthday_Celebrations.Models
{
    public class Citizen : ICreature, ICitizen, ITracking
    {
        public Citizen(string name, int age, string id, string date)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Date { get; set; }
    }
}
