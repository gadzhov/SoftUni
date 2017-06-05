using System;
using System.IO;

namespace _4.Copy_Binary_File
{
    class Startup
    {
        private const string SourcePath = "../../artwork.jpg";
        private const string DestinationPath = "../../artwork-copy.jpg";

        static void Main(string[] args)
        {
            using (var source = new FileStream(SourcePath, FileMode.Open))
            {
                using (var destination = new FileStream(DestinationPath, FileMode.Create))
                {
                    var fileLength = source.Length;
                    var buffer = new byte[4096];
                    while (true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
