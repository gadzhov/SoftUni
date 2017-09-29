namespace _2._Slice_File
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            // Add movie.avi to your directory!
            SliceAsync(".\\.\\movie.avi", ".\\.\\Pieces", 5);
            Console.WriteLine("Anything else?");
            Console.ReadLine();
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);
                long partLength = source.Length / parts + 1;
                long currentByte = 0;

                for (int currentPart = 0; currentPart < parts; currentPart++)
                {
                    string filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (FileStream destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[1024];
                        while (currentByte <= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }
        }

        private static async void SliceAsync(string sourceFile, string destinationParh, int parts)
        {
            await Task
                .Run(() => Slice(sourceFile, destinationParh, parts));
        }
    }
}
