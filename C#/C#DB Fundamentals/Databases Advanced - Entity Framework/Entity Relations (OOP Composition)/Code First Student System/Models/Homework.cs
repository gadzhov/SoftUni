using System;
using System.ComponentModel.DataAnnotations;

namespace Code_First_Student_System.Models
{
    public class Homework
    {
        private string contentType;
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType
        {
            get { return contentType; }
            set
            {
                if (value == "application" || value == "pdf" || value == "zip")
                {
                    contentType = value;
                }
                else
                {
                    throw new ArgumentException("ContentType is not valid!");
                }
            }
        }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
