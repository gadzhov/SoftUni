using System.Collections.Generic;
using System.Linq;
using Problem_9.Collection_Hierarchy.Interfces;

namespace Problem_9.Collection_Hierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public AddRemoveCollection()
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
            var lastItem = this.Collection.Last();
            this.Collection.Remove(lastItem);

            return lastItem;
        }
    }
}
