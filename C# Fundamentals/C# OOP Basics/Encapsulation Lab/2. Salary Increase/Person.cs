public class Person
{
    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    private string FirstName { get; }

    private string LastName { get; }

    private int Age { get; }

    private double Salary { get; set; }

    public void IncreaseSalary(double percent)
    {
        if (this.Age > 30)
        {
            this.Salary += this.Salary * percent / 100;
        }
        else
        {
            this.Salary += this.Salary * percent / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.Salary:F2} leva";
    }
}

