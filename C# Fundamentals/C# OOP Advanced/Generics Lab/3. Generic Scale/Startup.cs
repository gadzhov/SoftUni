using System;

public class Startup
{
    public static void Main()
    {
        var scale = new Scale<string>("a", "a");
        Console.WriteLine(scale.GetHavier());
    }
}
