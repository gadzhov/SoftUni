using System.IO;

public class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;
    private double _salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    private string FirstName
    {
        get { return this._firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new InvalidDataException("First name cannot be less than 3 symbols");
            }
            this._firstName = value;
        }
    }

    private string LastName
    {
        get { return this._lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new InvalidDataException("Last name cannot be less than 3 symbols");
            }
            this._lastName = value;
        }
    }

    private int Age
    {
        get { return this._age; }
        set
        {
            if (value <= 0)
            {
                throw new InvalidDataException("Age cannot be zero or negative integer");
            }
            this._age = value;
        }
    }

    private double Salary
    {
        get { return this._salary; }
        set
        {
            if (value < 460)
            {
                throw new InvalidDataException("Salary cannot be less than 460 leva");
            }
            this._salary = value;
        }
    }

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
        return $"{this.FirstName} {this.LastName} get {this.Salary:F1} leva";
    }
}

