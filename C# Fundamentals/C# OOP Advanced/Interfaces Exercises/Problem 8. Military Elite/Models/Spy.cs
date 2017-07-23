using System.Text;
using Problem_8.Military_Elite.Interfaces;

namespace Problem_8.Military_Elite.Models
{
    public class Spy : ISoldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, string codeNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CodeNumber = codeNumber;
        }

        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string CodeNumber { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}")
                .AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString().Trim();
        }
    }
}
