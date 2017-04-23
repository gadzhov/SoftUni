using PhotoShare.Data;

namespace PhotoShare.Client
{
    using Core;

    public class Application
    {
        public static void Main()
        {
            //var context = new PhotoShareContext();
            //context.Database.Initialize(true);
            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }
    }
}
