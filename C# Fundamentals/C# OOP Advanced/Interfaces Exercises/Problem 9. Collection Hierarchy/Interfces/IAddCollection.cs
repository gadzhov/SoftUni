using System.Collections.Generic;

namespace Problem_9.Collection_Hierarchy.Interfces
{
    public interface IAddCollection
    {
        List<string> Collection { get; }

        string Add(string item);
    }
}
