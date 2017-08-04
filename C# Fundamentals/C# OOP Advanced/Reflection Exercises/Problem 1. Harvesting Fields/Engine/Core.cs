using System;
using System.Linq;
using Problem_1.Harvesting_Fields.Engine.Commands;

namespace Problem_1.Harvesting_Fields.Engine
{
    public static class Core
    {
        public static void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                // Input is lowerCase, but classes names starts with uppercase and reflection won't wor
                var firstLetter = input.First().ToString().ToUpper();
                input = input.Replace(input.First().ToString(), firstLetter);

                // Get command's type
                var commandType = Type.GetType("Problem_1.Harvesting_Fields.Engine.Commands." + input + "Command");

                if (commandType == null)
                {
                    throw new NotSupportedException($"Command {input} not supported!");
                }

                // Create instance of command
                var command = Activator.CreateInstance(commandType);

                // Get Method called "Execute"
                var executeMethod = command.GetType().GetMethod("Execute");

                // Invoke the method
                var result = executeMethod.Invoke(command, new object[] { }) as string;

                Console.WriteLine(result);
            }
        }
    }
}
