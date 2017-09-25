namespace BankSystem
{
    using BankSystem.Core;

    public class Startup
    {
        public static void Main()
        {
            BankSystemController bankSystemController = new BankSystemController();
            Engine engine = new Engine(bankSystemController);
            engine.Run();
        }
    }
}
