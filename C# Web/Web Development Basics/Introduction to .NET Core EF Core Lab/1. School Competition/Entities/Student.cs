namespace _1._School_Competition.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public ICollection<string> Categories { get; } = new HashSet<string>();

        public int TotalPoints { get; set; }

        public override string ToString()
        {
            List<string> orderedCategories = this.Categories.OrderBy(c => c).ToList();
            return $"{this.Name}: {this.TotalPoints} [{string.Join(", ", orderedCategories)}]";
        }
    }
}