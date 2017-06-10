using System;

namespace _3.Parse_Tags
{
    class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var openingTag = "<upcase>";
            var closingTag = "</upcase>";

            var indexStart = text.IndexOf(openingTag);

            try
            {
                while (indexStart != 1)
                {
                    var indexClose = text.IndexOf(closingTag);
                    if (indexClose == -1)
                    {
                        break;
                    }
                    var tagedText = text.Substring(indexStart, indexClose - indexStart + closingTag.Length);
                    var tagedTextToUpCase = tagedText
                        .Replace(openingTag, string.Empty)
                        .Replace(closingTag, string.Empty)
                        .ToUpper();
                    text = text.Replace(tagedText, tagedTextToUpCase);

                    indexStart = text.IndexOf(openingTag);

                }
            }
            catch
            {
                //ignore
            }
            Console.WriteLine(text);
        }
    }
}
