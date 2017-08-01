using System;
using System.Linq;
using Problem_10.Create_Custom_Class_Attribute.Attributes;

namespace Problem_10.Create_Custom_Class_Attribute
{
    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class Startup
    {
        private static void Main()
        {
            var input = string.Empty;

            var attr = (InfoAttribute)typeof(Startup).GetCustomAttributes(true).First();

            while ((input = Console.ReadLine()) != "END")
            {
                attr.PrintInfo(input);
            }
        }
    }
}
