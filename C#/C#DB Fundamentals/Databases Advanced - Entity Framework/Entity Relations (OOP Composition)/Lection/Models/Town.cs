using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lection.Models
{
    // Person & Town Multiple Relation
    public class Town
    {
        public Town()
        {
            this.Natives = new HashSet<Person>();
            this.Residents = new HashSet<Person>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("PlaceOfBirth")]
        public virtual ICollection<Person> Natives { get; set; }
        [InverseProperty("CurrentResidence")]
        public virtual ICollection<Person> Residents { get; set; }
    }
}
