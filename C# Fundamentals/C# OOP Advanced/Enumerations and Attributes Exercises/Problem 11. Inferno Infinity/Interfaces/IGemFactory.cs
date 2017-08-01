using System.Collections.Generic;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IGemFactory
    {
        IBaseGem Create(IList<string> tokens);
    }
}
