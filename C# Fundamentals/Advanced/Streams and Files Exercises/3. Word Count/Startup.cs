using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.Word_Count
{
    class Startup
    {
        static void Main(string[] args)
        {
            using (var readerWords = new StreamReader("../../words.txt"))
            {
                var words = new Dictionary<string, int>();
                var line = readerWords.ReadLine();
                while (line != null)
                {
                    if (!words.ContainsKey(line.ToLower()))
                    {
                        words.Add(line, 0);
                    }
                    line = readerWords.ReadLine();
                }
                using (var readerText = new StreamReader("../../text.txt"))
                {
                    line = readerText.ReadLine();
                    while (line != null)
                    {
                        var wordsArray = line.Split(new[] {',', '.', '?', '!', ' ', '-'},
                            StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in wordsArray)
                        {
                            if (words.ContainsKey(word.ToLower()))
                            {
                                words[word.ToLower()]++;
                            }
                        }
                        line = readerText.ReadLine();
                    }
                    using (var writer = new StreamWriter("../../result.txt"))
                    {
                        foreach (var w in words.OrderByDescending(w => w.Value))
                        {
                            writer.WriteLine($"{w.Key} - {w.Value}");
                        }
                    }
                }
            }
        }
    }
}
