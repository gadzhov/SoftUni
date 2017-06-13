using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _11.Semantic_HTML
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            const string pattern = "<div\\s\\w*\\s*.*(?<key>id|class)\\s*=\\s*\"(?<value>\\w+)\"\\s*";
            var regex = new Regex(pattern);

            var key = string.Empty;
            var value = new Stack<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                var match = regex.Match(input);
                if (match.Success)
                {
                    key = match.Groups["key"].Value;
                    value.Push(match.Groups["value"].Value);
                    var replaceTag = Regex.Replace(input, "<div", $"<{value.Peek()}"); // <div => <head
                    var replaceAtributes = Regex.Replace(replaceTag, $"{key}\\s*=\\s*\"{value.Peek()}\"\\s*", ""); // <div style="color:red" id="header"> => <header style="color:red">
                    replaceAtributes = Regex.Replace(replaceAtributes, "\\s*>", ">"); // <div style="color:red" "> Removes Space before >
                    replaceAtributes = Regex.Replace(replaceAtributes, "\\s+", " "); // makes the HTML sematic (removes all multiple spaces)
                    Console.WriteLine(replaceAtributes);
                }
                else if (input.Contains("</div"))
                {
                    var closingTag = Regex.Replace(input, $"<\\/div>\\s*<!--\\s*\\w+\\s*-->\\s*", $"</{value.Pop()}>");
                    Console.WriteLine(closingTag);
                }
                else
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
