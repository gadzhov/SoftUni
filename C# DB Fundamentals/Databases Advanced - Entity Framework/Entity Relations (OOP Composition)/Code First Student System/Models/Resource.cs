using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Code_First_Student_System.Models
{
    public class Resource
    {
        private string resourceType;
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ResourceType
        {
            get { return resourceType; }
            set
            {
                if (value == "Video" || value == "Presentation" || value == "Document" || value == "Other")
                {
                    resourceType = value;
                }
                else
                {
                    throw new ArgumentException("ResourceType is not valid!");
                }
            }
        }

        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<License> Licenses { get; set; }
    }
}
