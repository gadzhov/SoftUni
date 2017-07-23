using Problem_6.Birthday_Celebrations.Interfaces;

namespace Problem_6.Birthday_Celebrations.Models
{
    public class Pet : ICreature
    {
        public Pet(string name, string date)
        {
            this.Name = name;
            this.Date = date;
        }

        public string Name { get; set; }

        public string Date { get; set; }
    }
}
