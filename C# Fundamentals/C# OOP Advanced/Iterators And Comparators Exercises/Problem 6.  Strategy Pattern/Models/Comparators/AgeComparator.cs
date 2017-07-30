using System.Collections.Generic;

namespace Problem_6.Strategy_Pattern.Models.Comparators
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
