using System.Collections.Generic;
using System.Linq;
using Problem_9.Collection_Hierarchy.Interfces;

namespace Problem_9.Collection_Hierarchy.Models
{
    public class MyList : IMyList
    {
        public MyList()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public string Add(string item)
        {
            this.Collection.Insert(0, item);

            return "0";
        }

        public string Remove()
        {
            var firstEle = this.Collection.First();
            this.Collection.Remove(firstEle);

            return firstEle;
        }

        public int Used()
        {
            return this.Collection.Count;
        }
    }
}
