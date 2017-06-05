using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _6.Zipping_Sliced_Files
{
    class Startup
    {
        static void Main(string[] args)
        {
            var sourceFile = "../../text.txt";
            var destinationDirectory = "../../";
            var parts = 4;
            var sourceFiles = new List<string>() { "../../Part_1zipped.gz", "../../Part_2zipped.gz", "../../Part_3zipped.gz", "../../Part_4zipped.gz" };

            //using (var source = new StreamWriter(sourceFile))
            //{
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        source.WriteLine(i);
            //    }
            //}
            Slice(sourceFile, destinationDirectory, parts);
            Assembly(sourceFiles, destinationDirectory);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                for (int i = 0; i < parts; i++)
                {
                    long currentPartSize = 0;
                    var destinationFile = destinationDirectory + $"part_{i + 1}zipped.gz";
                    using (var destination = new FileStream(destinationFile, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            var partSize = source.Length / parts + source.Length % parts;
                            var buffer = new byte[4096];
                            while (currentPartSize <= partSize)
                            {
                                var readBytes = source.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }
                                compressionStream.Write(buffer, 0, buffer.Length);
                                currentPartSize += readBytes;
                            }
                        }
                    }
                }
            }
        }

        private static void Assembly(List<string> sourceFiles, string destinationDirectory)
        {
            foreach (var sourceFile in sourceFiles)
            {
                using (var source = new FileStream(sourceFile, FileMode.Open))
                {
                    var destinationFile = destinationDirectory + "unzipped.txt";
                    using (var compressionStrem = new GZipStream(source, CompressionMode.Decompress, false))
                    {
                        using (var destination = new FileStream(destinationFile, FileMode.Append))
                        {
                            var buffer = new byte[4096];
                            while (true)
                            {
                                var readBytes = compressionStrem.Read(buffer, 0, buffer.Length);
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
    }
}
