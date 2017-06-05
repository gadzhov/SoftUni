using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7.Directory_Traversal
{
    public class Startup
    {
        private static void Main()
        {
            // get and store file info about all files in the current directory
            string[] filePaths = Directory.GetFiles(@"../../");

            List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

            // sort file info
            var sorted =
                files.OrderBy(file => file.Length).GroupBy(file => file.Extension)
                    .OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

            // locate desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // create report file
            using (StreamWriter writer = new StreamWriter(desktop + "/report.txt"))
            {
                foreach (var group in sorted)
                {
                    writer.WriteLine(group.Key);

                    foreach (var y in group)
                    {
                        writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
                    }
                }
            }

            // open report file
            System.Diagnostics.Process.Start(desktop + "/report.txt");
        }
    }
}