using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_3.Mankind.Models
{
    public class Student : Human
    {
        private string _facultyNumber;

        public Student(string firstName, string lastName, string facilityNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facilityNumber;
        }

        private string FacultyNumber
        {
            get => this._facultyNumber;
            set
            {
                if (value.Length < 5 || value.Length > 10 ||
                    !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                _facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}
