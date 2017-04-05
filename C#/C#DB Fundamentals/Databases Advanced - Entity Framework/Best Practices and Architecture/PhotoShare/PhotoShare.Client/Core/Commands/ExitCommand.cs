namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public void Execute()
        {
            Console.WriteLine("Bye-bye!");
            Environment.Exit(0);
        }
    }
}
