namespace Problem_2.Creating_Constructors
{
    class Person
    {
        public string name;
        public int age;

        public Person(string name, int age) : this(age)
        {
            this.name = name;
            this.age = age;
        }

        public Person(int age) : this()
        {
            this.age = age;
        }

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
