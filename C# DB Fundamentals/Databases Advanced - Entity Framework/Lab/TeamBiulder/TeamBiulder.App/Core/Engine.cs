using System;

namespace TeamBiulder.App.Core
{
    public class Engine
    {
        private readonly CommandDispatcher _commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this._commandDispatcher = commandDispatcher;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var output = this._commandDispatcher.Dispatch(input);

                    Console.WriteLine(output);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}
