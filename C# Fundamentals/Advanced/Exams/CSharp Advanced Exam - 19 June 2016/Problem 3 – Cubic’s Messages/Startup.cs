using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_3___Cubic_s_Messages
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Over!")
            {
                var m = int.Parse(Console.ReadLine());
                var pattern = $"^[0-9]+[a-zA-Z]{{{m}}}[^A-Za-z]*$";
                var regex = new Regex(pattern);

                var match = regex.Match(input);
                if (match.Success)
                {
                    var indexes = Regex.Replace(match.ToString(), "[A-Za-z]", string.Empty);
                    var vCode = new StringBuilder();
                    var message = Regex.Match(match.ToString(), "[A-Za-z]+");
                    vCode.Append($"{message} == ");
                    for (int i = 0; i < indexes.Length; i++)
                    {
                        try
                        {
                            var position = int.Parse(indexes[i].ToString());
                            vCode.Append(message.ToString()[position]);
                        }
                        catch
                        {
                            vCode.Append(" ");
                        }
                    }
                    Console.WriteLine(vCode.ToString().Trim());
                }
            }
        }
    }
}
