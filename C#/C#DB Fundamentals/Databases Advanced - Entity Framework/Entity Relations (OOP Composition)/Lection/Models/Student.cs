using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection.Models
{
    // Adress & Student 1 to 1 or 0 RS
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Adress Adress { get; set; }
    }
}
