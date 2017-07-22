using System;
using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Get(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        Provider provider = null;
        switch (type)
        {
            case "Pressure":
                provider = new PressureProvider(id, energyOutput);
                break;
            case "Solar":
                provider = new SolarProvider(id, energyOutput);
                break;
            default:
                provider = new PressureProvider(id, energyOutput);
                break;
        }

        return provider;
    }
}
