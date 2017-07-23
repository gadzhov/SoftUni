using System.Collections.Generic;
using System.Text;
using Problem_8.Military_Elite.Interfaces;

namespace Problem_8.Military_Elite.Models
{
    public class Commando : ISoldier, IPrivate, ISpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, double salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            Missions = new HashSet<Mission>();
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public double Salary { get; }

        public Corps Corps { get; }

        public ICollection<Mission> Missions { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}")
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}