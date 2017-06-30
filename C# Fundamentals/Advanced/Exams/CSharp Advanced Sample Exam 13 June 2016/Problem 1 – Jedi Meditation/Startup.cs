using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_1___Jedi_Meditation
{
    class Startup
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var jediMasters = new Queue<string>();
            var jediKnights = new Queue<string>();
            var jediPawadan = new Queue<string>();
            var toshkoAndSlav = new Queue<string>();
            var isYodaObserve = false;
            for (int i = 0; i < count; i++)
            {
                var inputTokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string jedai in inputTokens)
                {
                    switch (jedai[0].ToString())
                    {
                        case "m":
                            jediMasters.Enqueue(jedai);
                            break;
                        case "k":
                            jediKnights.Enqueue(jedai);
                            break;
                        case "p":
                            jediPawadan.Enqueue(jedai);
                            break;
                        case "t":
                            toshkoAndSlav.Enqueue(jedai);
                            break;
                        case "s":
                            toshkoAndSlav.Enqueue(jedai);
                            break;
                        case "y":
                            isYodaObserve = true;
                            break;
                    }
                }
            }
            var result = new StringBuilder();
            if (!isYodaObserve)
            {
                if (toshkoAndSlav.Count > 0)
                {
                    result.Append(string.Join(" ", toshkoAndSlav) + " ");
                }
                if (jediMasters.Count > 0)
                {
                    result.Append(string.Join(" ", jediMasters) + " ");
                }
                if (jediKnights.Count > 0)
                {
                    result.Append(string.Join(" ", jediKnights) + " ");
                }
                result.Append(string.Join(" ", jediPawadan));
            }
            else
            {
                if (jediMasters.Count > 0)
                {
                    result.Append(string.Join(" ", jediMasters) + " ");
                }
                if (jediKnights.Count > 0)
                {
                    result.Append(string.Join(" ", jediKnights) + " ");
                }
                if (toshkoAndSlav.Count > 0)
                {
                    result.Append(string.Join(" ", toshkoAndSlav) + " ");
                }
                result.Append(string.Join(" ", jediPawadan));
            }
            Console.WriteLine(result);
        }
    }
}
