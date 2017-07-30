using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Problem_3.Stack.Generics;

namespace Problem_3.Stack
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            var stack = new Stack<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            var elements = cmdArgs.Skip(1).ToArray();
                            stack.Push(elements);
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                        default:
                            throw new InvalidOperationException("Invalid Input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
        }
    }
}
