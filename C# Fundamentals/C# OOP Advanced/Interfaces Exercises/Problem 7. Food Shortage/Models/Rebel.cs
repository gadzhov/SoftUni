using Problem_7.Food_Shortage.Interfaces;

namespace Problem_7.Food_Shortage.Models
{
    public class Rebel : IRebel, IBuyer, IFood
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }

    }
}
