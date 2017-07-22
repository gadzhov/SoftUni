using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Get(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var engergyRequerement = double.Parse(arguments[3]);
        Harvester harvester = null;

        switch (type)
        {
            case "Hammer":
                harvester = new HammerHarvester(id, oreOutput, engergyRequerement);
                break;
            case "Sonic":
                var sonicFactor = int.Parse(arguments[4]);
                harvester = new SonicHarvester(id, oreOutput, engergyRequerement, sonicFactor);
                break;
            default:
                harvester = new HammerHarvester(id, oreOutput, engergyRequerement);
                break;
        }

        return harvester;
    }
}
