using System;
using System.IO;

namespace _2.Line_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../lorem.txt"))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var line = reader.ReadLine();
                    var counter = 1;
                    while (line != null)
                    {
                        var appendLine = $"{counter}. {line}";
                        writer.WriteLine(appendLine);
                        line = reader.ReadLine();
                        counter++;
                    }
                    Console.WriteLine($"Successfully modified {counter} lines");
                }
            }
        }
    }
}
