using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Nation fireNation;
    private Nation airNation;
    private Nation waterNation;
    private Nation earthNation;
    private Dictionary<int, string> warLog;
    private static int warLogCounter = 1;

    public NationsBuilder()
    {
        this.fireNation = new Nation();
        this.airNation = new Nation();
        this.waterNation = new Nation();
        this.earthNation = new Nation();
        warLog = new Dictionary<int, string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        //•	Bender {type} {name} {power} {secondaryParameter}
        var type = benderArgs[1];
        var name = benderArgs[2];
        var power = int.Parse(benderArgs[3]);
        var secondaryParam = double.Parse(benderArgs[4]);

        Bender bender;
        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, secondaryParam);
                this.airNation.AddBender(bender);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondaryParam);
                this.waterNation.AddBender(bender);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondaryParam);
                this.fireNation.AddBender(bender);
                break;
            case "Earth":
                bender = new EarthBender(name, power, secondaryParam);
                this.earthNation.AddBender(bender);
                break;
            default:
                throw new InvalidOperationException("Invalid Bender Type!");
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        // •	Monument {type} {name} {affinity}
        var type = monumentArgs[1];
        var name = monumentArgs[2];
        var affinity = int.Parse(monumentArgs[3]);

        Monument monument;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                this.airNation.AddMonuments(monument);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                this.waterNation.AddMonuments(monument);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                this.fireNation.AddMonuments(monument);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                this.earthNation.AddMonuments(monument);
                break;
            default:
                throw new InvalidOperationException("Invalid Monument Type");
        }
    }
    public string GetStatus(string nationsType)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");

        switch (nationsType)
        {
            case "Air":
                return sb.Append(this.airNation).ToString();
            case "Fire":
                return sb.Append(this.fireNation).ToString();
            case "Water":
                return sb.Append(this.waterNation).ToString();
            case "Earth":
                return sb.Append(this.earthNation).ToString();
            default:
                throw new InvalidOperationException("Invalid Nation Type!");
        }
    }
    public void IssueWar(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                this.warLog.Add(warLogCounter, "Air");
                break;
            case "Fire":
                this.warLog.Add(warLogCounter, "Fire");
                break;
            case "Water":
                this.warLog.Add(warLogCounter, "Water");
                break;
            case "Earth":
                this.warLog.Add(warLogCounter, "Earth");
                break;
            default:
                throw new InvalidOperationException("Invalid Nation Type!");
        }
        warLogCounter++;
        Nation.CalculatePoints(new List<Nation>{this.fireNation, this.airNation, this.earthNation, this.waterNation});
    }
    public string GetWarsRecord()
    {
        var sb = new StringBuilder();  
        foreach (var nation in this.warLog)
        {
            sb.AppendLine($"War {nation.Key} issued by {nation.Value}");
        }

        return sb.ToString().Trim();
    }

}