using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Problem_4.Online_Radio_Database.Models;

namespace Problem_4.Online_Radio_Database
{
    class Startup
    {
        static void Main(string[] args)
        {
            var radio = new Radio();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    var songArgs = Console.ReadLine()
                        .Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    var song = new Song(songArgs[0], songArgs[1], songArgs[2]);

                    radio.AddSong(song);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(radio);
        }
    }
}
