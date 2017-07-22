using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public List<Bender> Benders { get; set; }

    public List<Monument> Monuments { get; set; }

    public void AddBender(Bender bender)
    {
        this.Benders.Add(bender);
    }

    public void AddMonuments(Monument monument)
    {
        this.Monuments.Add(monument);
    }

    public static void CalculatePoints(List<Nation> nations)
    {
        var maxPoints = 0;
        Nation winner = null;
        foreach (var nation in nations)
        {
            var currentPoint = nation.Benders.Sum(b => b.Power) + nation.Monuments.Sum(m => m.GetBonus());
            if (currentPoint > maxPoints)
            {
                maxPoints = currentPoint;
                winner = nation;
            }
        }
        nations.Remove(winner);
        var nationLooseTheWar = nations;
        Nation.RemoveMonumentsAndBender(nationLooseTheWar);
    }

    private static void RemoveMonumentsAndBender(List<Nation> nationLooseTheWar)
    {
        foreach (var nation in nationLooseTheWar)
        {
            nation.Benders.Clear();
            nation.Monuments.Clear();
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        if (this.Benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in this.Benders)
            {
                sb.AppendLine($"###{bender}");
            }
        }

        if (this.Monuments.Count == 0)
        {
            sb.Append("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine($"###{monument}");
            }
        }
        return sb.ToString().Trim();
    }
}
