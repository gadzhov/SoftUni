using System;
using TeamBiulder.App.Utilities;

namespace TeamBiulder.App.Core.Commands
{
    class ExitCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            Console.WriteLine("Bye!");
            Environment.Exit(0);
            return "Bye!";
        }
    }
}
