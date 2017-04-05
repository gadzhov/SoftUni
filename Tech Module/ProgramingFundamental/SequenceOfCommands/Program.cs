using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            int[] args = new int[2];

            if (command.Contains("add") ||
                command.Contains("subtract") ||
                command.Contains("multiply"))
            {
                string[] stringParams = command.Split(ArgumentsDelimiter);
                string action = stringParams[0];
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);

               array = PerformAction(array, action, args);
            }
            else if(command.Contains("lshift"))
            {
                long temp = 0;
                ArrayShiftLeft(array, temp);
            }
            else if (command.Contains("rshift"))
            {
                long temp = 0;
                ArrayShiftRight(array, temp);
            }

            PrintArray(array);

            command = Console.ReadLine();
        }
    }

    static long[] PerformAction(long[] arr, string action, int[] args)
    {
        long[] array = arr.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];
        
        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
        }
        return array;
    }

    private static void ArrayShiftRight(long[] array, long temp)
    {
        temp = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = temp;
    }

    private static void ArrayShiftLeft(long[] array, long temp)
    {
        temp = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = temp;
    }

    private static void PrintArray(long[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
}
