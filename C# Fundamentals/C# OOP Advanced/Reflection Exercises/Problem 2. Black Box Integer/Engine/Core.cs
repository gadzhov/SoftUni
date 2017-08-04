using System;
using Problem_2.Black_Box_Integer.Models;

namespace Problem_2.Black_Box_Integer.Engine
{
    public static class Core
    {
        public static void Run()
        {
            string input;
            // typeof(BlackBoxInt), true --- Create instance of a class with private ctor
            var blackBoxInstance = Activator.CreateInstance(typeof(BlackBoxInt), true);
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                var command = cmdArgs[0];
                var value = int.Parse(cmdArgs[1]);

                var commandType = Type.GetType("Problem_2.Black_Box_Integer.Engine.Commands." + command + "Command");

                if (commandType == null)
                {
                    throw new NotSupportedException($"Command {command} not supported!");
                }

                var commandInstance = Activator.CreateInstance(commandType);
                var executeMethod = commandInstance.GetType().GetMethod("Execute");
                var result = executeMethod.Invoke(commandInstance, new object[] { blackBoxInstance, value }) as string;

                Console.WriteLine(result);
            }
        }
    }
}
