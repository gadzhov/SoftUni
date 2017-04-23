using System.Collections.Generic;

namespace Exercises.Models
{
    public class Standard
    {
        public Standard()
        {
            this.Students = new HashSet<Student>();
        }
        public int StandardKey { get; set; }
        public string StandardName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
