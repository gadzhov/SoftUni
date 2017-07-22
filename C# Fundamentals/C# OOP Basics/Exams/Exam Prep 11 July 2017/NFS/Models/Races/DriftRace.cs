using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override List<Car> GetWinners()
    {
        return base.Participants
            .Values
            .OrderByDescending(p => p.SuspensionPerformance())
            .Take(3)
            .ToList();
    }

    public override string GetPrizePool()
    {
        var winners = this.GetWinners();
        var prize = 0.5;
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");
        var counter = 1;

        foreach (var car in winners)
        {
            if (counter == 2)
            {
                prize = 0.3;
            }
            if (counter == 3)
            {
                prize = 0.2;
            }
            sb.AppendLine(
                $"{counter}. {car.Brand} {car.Model} {car.SuspensionPerformance()}PP - ${this.PrizePool * prize}");
            counter++;
        }

        return sb.ToString();
    }
}
