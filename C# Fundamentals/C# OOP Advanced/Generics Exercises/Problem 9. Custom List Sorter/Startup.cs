using System;
using Problem_9.Custom_List_Sorter.Generics;

namespace Problem_9.Custom_List_Sorter
{
   public class Startup
    {
        public static void Main()
        {
            var customList = new CustomList<string>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = cmdArgs[0];

                switch (command)
                {
                    case "Add":
                        customList.Add(cmdArgs[1]);
                        break;
                    case "Remove":
                        customList.Remove(int.Parse(cmdArgs[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(customList.Contains(cmdArgs[1]));
                        break;
                    case "Swap":
                        customList.Swap(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(customList.CountGreaterThan(cmdArgs[1]));
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Print":
                        foreach (var item in customList)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "Sort":
                        customList.Sort();
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
        }
    }
}
