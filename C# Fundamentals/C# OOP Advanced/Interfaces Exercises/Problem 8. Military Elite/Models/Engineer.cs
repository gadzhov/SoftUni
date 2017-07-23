using System.Collections.Generic;
using System.Text;
using Problem_8.Military_Elite.Interfaces;

namespace Problem_8.Military_Elite.Models
{
    public class Engineer : ISoldier, IPrivate,ISpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, double salary, Corps corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Repairs = new HashSet<Repair>();
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public double Salary { get; }

        public Corps Corps { get; }

        public ICollection<Repair> Repairs { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
