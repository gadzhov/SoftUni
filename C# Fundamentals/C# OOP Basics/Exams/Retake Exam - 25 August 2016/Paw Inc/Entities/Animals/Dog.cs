namespace Paw_Inc.Entities.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, int amountOfCommands) 
            : base(name, age)
        {
            this.AmountOfCommands = amountOfCommands;
        }

        public int AmountOfCommands { get; set; }
    }
}
