using TeamBiulder.App.Core;

namespace TeamBiulder.App
{
    class Application
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
