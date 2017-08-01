using System;
using Problem_11.Inferno_Infinity.Interfaces;

namespace Problem_11.Inferno_Infinity.Core
{
    public class OutputHandler : IOutputHandler
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
