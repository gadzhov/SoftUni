using System;
using System.Linq;
using Problem_2.Collection.Generics;

namespace Problem_2.Collection
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            ListyIterator<string> listyIterator = null;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];

                try
                {
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
                            Console.WriteLine(listyIterator.Print());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "PrintAll":
                            Console.WriteLine(listyIterator.PrintAll());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
