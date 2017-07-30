namespace Problem_8.Pet_Clinics.Models
{
    public class Pet
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name { get; }

        private int Age { get; }

        private string Kind { get; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}