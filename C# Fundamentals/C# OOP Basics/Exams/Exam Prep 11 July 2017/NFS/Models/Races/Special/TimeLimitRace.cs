using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; set; }

    public bool IsRaceFree()
    {
        return base.Participants.Count == 0;
    }

    public int TimePerformance()
    {
        return base.Length * ((base.Participants.FirstOrDefault().Value.HorsePower / 100) *
                              base.Participants.FirstOrDefault().Value.Acceleration);
    }

    public override List<Car> GetWinners()
    {
        return base.Participants
            .Values
            .ToList();
    }

    public override string GetPrizePool()
    {
        var winner = this.GetWinners()
            .FirstOrDefault();
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        sb.AppendLine($"{winner.Brand} {winner.Model} - {this.TimePerformance()} s.");

        if (this.TimePerformance() <= this.GoldTime)
        {
            sb.AppendLine($"Gold Time, ${base.PrizePool}.");
        }
        else if (this.TimePerformance() <= this.GoldTime + 15)
        {
            sb.AppendLine($"Silver Time, ${(int) (base.PrizePool * 0.5)}.");
        }
        else if (this.TimePerformance() > this.GoldTime + 15)
        {
            sb.AppendLine($"Bronze Time, ${base.PrizePool * 0.3}.");
        }

        return sb.ToString();
    }
}
