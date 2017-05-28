using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class SrabskoUnleashed
{
    private static void Main()
    {
        var rgx = new Regex(@"(\D+)\s@(\D+)\s(\d+)\s(\d+)");

        var eventsInfo = new Dictionary<string, Dictionary<string, int>>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var match = rgx.Match(input);
            if (match.Success)
            {
                var singer = match.Groups[1].Value.Trim();
                var town = match.Groups[2].Value.Trim();
                var ticketPrice = int.Parse(match.Groups[3].Value);
                var ticketsCount = int.Parse(match.Groups[4].Value);

                if (!eventsInfo.ContainsKey(town))
                {
                    eventsInfo[town] = new Dictionary<string, int>();
                }
                if (!eventsInfo[town].ContainsKey(singer))
                {
                    eventsInfo[town][singer] = 0;
                }

                eventsInfo[town][singer] += ticketPrice * ticketsCount;
            }
        }

        foreach (var pair in eventsInfo)
        {
            Console.WriteLine(pair.Key);
            foreach (var concertInfo in pair.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine("#  {0} -> {1}", concertInfo.Key, concertInfo.Value);
            }
        }
    }
}