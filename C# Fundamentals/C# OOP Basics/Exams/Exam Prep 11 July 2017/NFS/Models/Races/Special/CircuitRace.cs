using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; set; }

    public override List<Car> GetWinners()
    {
        base.DecreaseDurability(this.Length * this.Length * Laps);
        return base.Participants
            .Values
            .OrderByDescending(p => p.OverallPerformance())
            .Take(4)
            .ToList();
    }

    public override string GetPrizePool()
    {
        var winners = this.GetWinners();
        var sb = new StringBuilder();
        var prize = 0.4;
        var counter = 1;
        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        foreach (var winner in winners)
        {
            sb.AppendLine(
                $"{counter}. {winner.Brand} {winner.Model} {winner.OverallPerformance()}PP - ${this.PrizePool * prize}");

            counter++;
            prize -= 0.1;
        }

        return sb.ToString();
    }
}
