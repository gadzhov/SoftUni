public class Person
{
    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public string FirstName { get; set; }

    private string LastName { get; set; }

    public int Age { get; set; }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is a {this.Age} years old";
    }
}
