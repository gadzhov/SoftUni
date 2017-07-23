using System.Collections.Generic;
using Problem_9.Collection_Hierarchy.Interfces;

namespace Problem_9.Collection_Hierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public string Add(string item)
        {
            this.Collection.Add(item);

            return (this.Collection.Count - 1).ToString();
        }
    }
}
