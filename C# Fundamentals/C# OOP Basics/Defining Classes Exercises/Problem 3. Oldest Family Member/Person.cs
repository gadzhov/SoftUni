namespace Problem_3.Oldest_Family_Member
{
    class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
