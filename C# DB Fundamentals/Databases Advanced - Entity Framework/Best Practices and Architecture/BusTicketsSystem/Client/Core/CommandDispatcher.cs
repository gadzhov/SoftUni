using System.Linq;
using Client.Core.Commands;
using Services;

namespace Client.Core
{
    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var command = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            var result = string.Empty;

            switch (command)
            {
                case "print-info":
                    var printInfo = new PrintCommand(new BusService());
                    printInfo.Execute(commandParameters);
                    break;
            }

            return result;
        }
    }
}
