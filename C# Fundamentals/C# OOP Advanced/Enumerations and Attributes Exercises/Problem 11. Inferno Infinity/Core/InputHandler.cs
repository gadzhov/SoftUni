using System;
using System.Collections.Generic;
using System.Linq;
using Problem_11.Inferno_Infinity.Interfaces;

namespace Problem_11.Inferno_Infinity.Core
{
    public class InputHandler : IInputHandler
    {
        public List<string> SplitInput(string input, string splitValue)
        {
            return input.Split(new string[] { $"{splitValue}" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
