using Client.Core;
using Data;

namespace Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            var commandDispatcher = new CommandDispatcher();
            var engine = new Engine(commandDispatcher);
            engine.Run();
        }
    }
}
