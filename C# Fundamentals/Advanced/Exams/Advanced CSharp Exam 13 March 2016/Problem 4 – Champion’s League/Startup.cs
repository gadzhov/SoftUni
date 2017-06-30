namespace Problem_4___Champion_s_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionsLeague
    {
        private static readonly IDictionary<string, int> winStatistics =
            new Dictionary<string, int>();
        private static readonly IDictionary<string, ISet<string>> opponentStatistics =
            new Dictionary<string, ISet<string>>();

        public static void Main()
        {
            string line;
            while ((line = Console.ReadLine()) != "stop")
            {
                string[] lineArgs = line.Split('|').Select(s => s.Trim()).ToArray();
                string firstTeam = lineArgs[0];
                string secondTeam = lineArgs[1];

                string winningTeam = FindWinner(firstTeam, secondTeam, lineArgs[2], lineArgs[3]);
                AddTeamToWinStatistics(firstTeam, firstTeam == winningTeam);
                AddTeamToWinStatistics(secondTeam, secondTeam == winningTeam);

                AddOpponent(firstTeam, secondTeam);
                AddOpponent(secondTeam, firstTeam);
            }

            foreach (var kvPair in winStatistics.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
            {
                Console.WriteLine(kvPair.Key);
                Console.WriteLine("- Wins: " + kvPair.Value);
                Console.WriteLine("- Opponents: " + string.Join(", ", opponentStatistics[kvPair.Key]));
            }
        }

        private static string FindWinner(string firstTeam, string secondTeam,
            string firstScore, string secondScore)
        {
            int[] firstMatchGoals = GetGoals(firstScore);
            int[] secondMatchGoals = GetGoals(secondScore);

            int firstTeamGoals = firstMatchGoals[0] + secondMatchGoals[1];
            int secondTeamGoals = firstMatchGoals[1] + secondMatchGoals[0];

            if (firstTeamGoals == secondTeamGoals)
            {
                return firstMatchGoals[1] < secondMatchGoals[1] ? firstTeam : secondTeam;
            }

            return firstTeamGoals > secondTeamGoals ? firstTeam : secondTeam;
        }

        private static int[] GetGoals(string score)
        {
            return score.Split(':').Select(int.Parse).ToArray();
        }

        private static void AddTeamToWinStatistics(string team, bool isWinner)
        {
            if (!winStatistics.ContainsKey(team))
            {
                winStatistics[team] = 0;
            }

            if (isWinner)
            {
                winStatistics[team]++;
            }
        }

        private static void AddOpponent(string team, string opponent)
        {
            if (!opponentStatistics.ContainsKey(team))
            {
                opponentStatistics[team] = new SortedSet<string>();
            }

            opponentStatistics[team].Add(opponent);
        }
    }
}
