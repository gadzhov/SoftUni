using System.Collections.Generic;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IWeaponFactory
    {
        IWeapon Create(IList<string> tokens);
    }
}
