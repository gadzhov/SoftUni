using System.Collections.Generic;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IWeaponAttribute
    {
        string Author { get; }
        string Description { get; }
        IList<string> Reviewers { get; }
        int Revision { get; }

        string PrintInfo(string field);
    }
}
