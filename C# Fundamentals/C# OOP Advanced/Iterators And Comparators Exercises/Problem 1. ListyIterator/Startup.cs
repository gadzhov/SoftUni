using System;
using System.Linq;
using Problem_1.ListyIterator.Generics;

namespace Problem_1.ListyIterator
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            ListyIterator<string> listyIterator = null;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];

                switch (command)
                {
                    case "Create":
                        var elemnets = cmdArgs.Skip(1).ToArray();
                        listyIterator = new ListyIterator<string>(elemnets);
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(listyIterator.Print());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
        }
    }
}
