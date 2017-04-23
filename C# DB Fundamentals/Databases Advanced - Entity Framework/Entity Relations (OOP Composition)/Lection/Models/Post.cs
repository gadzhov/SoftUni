using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Comment & Post 1 to many RS 
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
