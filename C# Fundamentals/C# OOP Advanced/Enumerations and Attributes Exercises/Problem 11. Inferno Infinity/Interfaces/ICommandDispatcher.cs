using System.Collections.Generic;

namespace Problem_11.Inferno_Infinity.Interfaces
{
    public interface ICommandDispatcher
    {
        void ExecuteCommand(IList<string> tokens);
    }
}
