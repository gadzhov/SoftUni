using System;
using System.IO;
using System.Text;

namespace _1.Odd_Lines
{
    class Startup
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../sample.txt", Encoding.Default, true))
            {
                var counter = 0;
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
