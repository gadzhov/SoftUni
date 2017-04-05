using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAndClas.Models
{
    class Dog
    {
        public Dog(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }

        public Dog()
        {
            
        }

        public Dog(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public string Gender { get; set; }

        public void Bark()
        {
            Console.WriteLine("woof");
        }

        public string WoofName()
        {
            return Name + " Woof";
        }
    }
}
