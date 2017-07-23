using System.Collections.Generic;

namespace Problem_4.Telephony.Entities.Interfaces
{
    public interface IBrowse
    {
        ICollection<string> Sites { get; }

        string Browse(string url);
    }
}
