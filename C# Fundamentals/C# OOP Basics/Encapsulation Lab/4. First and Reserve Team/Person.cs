public class Person
{
    public Person(string firsName, string lastName, int age, double salary)
    {
        this.FirstName = firsName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public double Salary { get; set; }
}
