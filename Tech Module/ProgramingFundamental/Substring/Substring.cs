using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char search = 'p';
        bool hasMatch = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == search)
            {
                hasMatch = true;

                int endIndex = jump;

                if (endIndex >= text.Length)
                {
                    endIndex = text.Length;
                    string matchedString = text.Substring(i, endIndex);
                    Console.WriteLine(matchedString);
                    break;
                }
                else
                {
                    string matchedString = text.Substring(i, endIndex + 1);
                    Console.WriteLine(matchedString);
                    i = -1;
                    text = text.Substring(matchedString.Length);
                }
            }
            else
            {
                text = text.Substring(1);
                i = -1;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
