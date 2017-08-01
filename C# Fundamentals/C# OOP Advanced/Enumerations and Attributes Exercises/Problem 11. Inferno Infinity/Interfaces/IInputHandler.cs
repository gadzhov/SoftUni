using System.Collections.Generic;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface IInputHandler
    {
        List<string> SplitInput(string input, string splitValue);
    }
}
