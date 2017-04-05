using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photographers.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        // field is a string and shouldn't be nvarchar(max)
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string TagLabel { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
