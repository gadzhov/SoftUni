using System.Collections.Generic;

namespace Lection.Models
{
   public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> Natives { get; set; }
        public virtual ICollection<Person> Residents { get; set; }
    }
}
