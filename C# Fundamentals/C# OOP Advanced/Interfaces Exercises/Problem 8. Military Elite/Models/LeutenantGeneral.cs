using System.Collections.Generic;
using System.Text;
using Problem_8.Military_Elite.Interfaces;

namespace Problem_8.Military_Elite.Models
{
    public class LeutenantGeneral : ISoldier,IPrivate, ILeutenantGeneral
    {
        public LeutenantGeneral(int id, string firstName, string lastName, double salary)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Privates = new HashSet<Private>();
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public double Salary { get; }

        public ICollection<Private> Privates { get; }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine("Privates:");
            foreach (var p in this.Privates)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
