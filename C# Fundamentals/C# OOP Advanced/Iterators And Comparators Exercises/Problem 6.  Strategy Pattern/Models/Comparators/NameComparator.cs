using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6.Strategy_Pattern.Models.Comparators
{
     public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                result = x.Name.First().ToString().ToLower().CompareTo(y.Name.First().ToString().ToLower());
            }

            return result;
        }
    }
}
