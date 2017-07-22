using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalProvidedEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full Mode";
        this.totalProvidedEnergy = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var harvester = HarvesterFactory.Get(arguments);

        this.harvesters.Add(harvester);

        return $"Successfully registered {harvester.GetName()} Harvester - {harvester.Id}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        var provider = ProviderFactory.Get(arguments);

        this.providers.Add(provider);

        return $"Successfully registered {provider.GetName()} Provider - {provider.Id}";
    }
    public string Day()
    {
       var totalEnergyRequerement = this.harvesters.Sum(h => h.EnergyRequirement);
        var totalOreOutput = this.harvesters.Sum(h => h.OreOutput);
        var currentOreMined = 0.0;
        this.totalProvidedEnergy += this.providers.Sum(p => p.EnergyOutput);
        var energyToPrint = this.providers.Sum(p => p.EnergyOutput);

        if (this.mode == "Half")
        {
            totalEnergyRequerement *= 0.6;
            totalOreOutput *= 0.5;
        }
        if (this.mode == "Energy")
        {
            totalEnergyRequerement = 0;
            totalOreOutput = 0;
        }

        if (this.totalProvidedEnergy >= totalEnergyRequerement)
        {
            this.totalProvidedEnergy -= totalEnergyRequerement;
            this.totalMinedOre += totalOreOutput;
            currentOreMined = totalOreOutput;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyToPrint}")
            .Append($"Plumbus Ore Mined: {currentOreMined}");

        return sb.ToString();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (this.providers.Any(p => p.Id == id))
        {
            var provider = this.providers.FirstOrDefault(p => p.Id == id);

            return provider.ToString();
        }
        if (this.harvesters.Any(h => h.Id == id))
        {
            var harvest = this.harvesters.FirstOrDefault(h => h.Id == id);

            return harvest.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalProvidedEnergy}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }

}
