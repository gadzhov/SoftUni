using System;
using System.Collections.Generic;

namespace Problem_13.Family_Tree
{
    public class Person
    {
        public Person()
        {
            this.Children = new List<PersonChildren>();
            this.Parents = new List<PersonParents>();
        }
        public string Name { get; set; }

        public string BornDate { get; set; }

        public List<PersonParents> Parents { get; set; }

        public List<PersonChildren> Children { get; set; }
    }
}
