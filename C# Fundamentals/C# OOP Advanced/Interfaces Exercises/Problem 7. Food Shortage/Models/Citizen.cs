using Problem_7.Food_Shortage.Interfaces;

namespace Problem_7.Food_Shortage.Models
{
    public class Citizen : IHuman, ICitizen, ITracking, IFood, IBuyer
    {
        public Citizen(string name, int age, string id, string date)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string Date { get; set; }

        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
