namespace Paw_Inc.Entities
{
    public class Animal
    {
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            IsClean = false;
            IsCastrated = false;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsClean { get; set; }

        public bool IsCastrated { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
