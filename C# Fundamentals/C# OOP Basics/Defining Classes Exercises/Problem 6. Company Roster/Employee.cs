using System.Runtime.CompilerServices;

namespace Problem_6.Company_Roster
{
    public class Employee
    {
        private string email = "n/a";
        private int age = -1;

        public Employee()
        {
            this.Email = email;
            this.Age = age;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
