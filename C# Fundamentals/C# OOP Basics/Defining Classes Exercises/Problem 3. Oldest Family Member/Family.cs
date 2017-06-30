using System.Collections.Generic;
using System.Linq;

namespace Problem_3.Oldest_Family_Member
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.FirstOrDefault(p => this.People.Max(x => x.Age) == p.Age);
        }
    }
}
