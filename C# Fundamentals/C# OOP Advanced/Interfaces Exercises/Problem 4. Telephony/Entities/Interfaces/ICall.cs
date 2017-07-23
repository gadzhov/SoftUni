using System.Collections.Generic;

namespace Problem_4.Telephony.Entities.Interfaces
{
    public interface ICall
    {
        ICollection<string> Contacts { get; }

        string Call(string nunmber);
    }
}
