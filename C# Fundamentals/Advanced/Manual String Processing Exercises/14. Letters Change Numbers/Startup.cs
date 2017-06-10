using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _14.Letters_Change_Numbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var text = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var textList = new List<string>();
            var onlyNumbers = new List<int>();

            foreach (var t in text)
            {
                textList.Add(t);
            }


            var pattern = @"[0-9]+";
            var rgx = new Regex(pattern);
            for (var i = 0; i < textList.Count; i++)
            {
                var mth = rgx.Match(textList[i]);
                var a = Convert.ToString(mth.Groups[0]);
                var number = int.Parse(a);
                onlyNumbers.Add(number);
            }

            var sum = 0.0;

            for (var i = 0; i < text.Length; i++)
            {
                var sum1 = 0.0;
                if (char.IsUpper(text[i][0]))
                {
                    var convert = (double)Convert.ToChar(text[i][0]);
                    sum1 = onlyNumbers[i] / (convert - 64.0);
                }
                else
                {
                    var convert = (double)Convert.ToChar(text[i][0]);
                    sum1 = onlyNumbers[i] * (convert - 96.0);
                }
                if (char.IsUpper(text[i][text[i].Length - 1]))
                {
                    var convert = (double)Convert.ToChar(text[i][text[i].Length - 1]);
                    sum += sum1 - (convert - 64.0);
                }
                else
                {
                    var convert = (double)Convert.ToChar(text[i][text[i].Length - 1]);
                    sum += sum1 + (convert - 96.0);
                }
            }

            Console.WriteLine("{0:F2}", sum);
        }
    }
}
