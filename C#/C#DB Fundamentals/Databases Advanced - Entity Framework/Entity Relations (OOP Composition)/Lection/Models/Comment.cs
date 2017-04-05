using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Comment & Post 1 to many RS 
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }
    }
}
