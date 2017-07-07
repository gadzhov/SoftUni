using System;
using System.Text;

namespace Problem_3.Mankind.Models
{
    public class Worker : Human
    {
        private decimal _weekSalary;
        private decimal _workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private decimal WorkHoursPerDay
        {
            get => this._workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this._workHoursPerDay = value;
            }
        }


        private decimal WeekSalary
        {
            get => this._weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                _weekSalary = value;
            }
        }

        private decimal CalculateSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5m);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Week Salary: {this.WeekSalary:f2}")
                .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
                .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

            return sb.ToString();
        }
    }
}
