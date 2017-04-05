using System.Collections.Generic;

namespace Models
{
    public class Suplier
    {
       public Suplier()
        {
            this.Parts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
