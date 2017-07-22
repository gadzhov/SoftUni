using System;
using System.Collections.Generic;
using System.Linq;
using System_Split.Models;

namespace System_Split
{
    class Startup
    {
        static void Main()
        {
            var components = new Dictionary<string, Hardware>();
            var dumpLogs = new Dictionary<string, Dump>();
            string input;
            while ((input = Console.ReadLine()) != "System Split")
            {
                var splitArgs = input.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                var command = splitArgs[0];
                string name;
                int capacity;
                int memory;
                string hardware;
                string software;
                if (command != "Analyze" && command != "DumpAnalyze")
                {
                    splitArgs = splitArgs[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                }
                switch (command)
                {
                    case "RegisterPowerHardware":
                        name = splitArgs[0];
                        capacity = int.Parse(splitArgs[1]);
                        memory = int.Parse(splitArgs[2]);

                        var powerHardware = new Power(name, capacity, memory);

                        components.Add(name, powerHardware);
                        break;
                    case "RegisterHeavyHardware":
                        name = splitArgs[0];
                        capacity = int.Parse(splitArgs[1]);
                        memory = int.Parse(splitArgs[2]);

                        var heavyHardware = new Heavy(name, capacity, memory);

                        components.Add(name, heavyHardware);
                        break;
                    case "RegisterExpressSoftware":
                        hardware = splitArgs[0];
                        name = splitArgs[1];
                        capacity = int.Parse(splitArgs[2]);
                        memory = int.Parse(splitArgs[3]);

                        var expressSoftware = new Express(name, capacity, memory);

                        if (components.ContainsKey(hardware))
                        {
                            components[hardware].AddSoftWare(expressSoftware);
                        }
                        break;
                    case "RegisterLightSoftware":
                        hardware = splitArgs[0];
                        name = splitArgs[1];
                        capacity = int.Parse(splitArgs[2]);
                        memory = int.Parse(splitArgs[3]);

                        var lightSoftWare = new Light(name, capacity, memory);

                        if (components.ContainsKey(hardware))
                        {
                            components[hardware].AddSoftWare(lightSoftWare);
                        }
                        break;
                    case "ReleaseSoftwareComponent":
                        hardware = splitArgs[0];
                        software = splitArgs[1];

                        if (components.ContainsKey(hardware))
                        {
                            var softToDelete = components[hardware].Softwares.FirstOrDefault(s => s.Name == software);

                            if (softToDelete != null)
                            {
                                components[hardware].DestroySoftware(softToDelete);
                            }
                        }
                        break;
                    case "Analyze":
                        Console.WriteLine("System Analysis");
                        Console.WriteLine($"Hardware Components: {components.Keys.Count}");
                        Console.WriteLine($"Software Components: {components.Values.Sum(c => c.Softwares.Count)}");
                        Console.WriteLine($"Total Operational Memory: {components.Values.Sum(v => v.Softwares.Sum(s => s.MemoryConsumption))} / {components.Values.Sum(h => h.MaximumMemory)}");
                        Console.WriteLine($"Total Capacity Taken: {components.Values.Sum(s => s.Softwares.Sum(soft => soft.CapacityConsumption))} / {components.Values.Sum(h => h.MaximumCapacity)}");
                        break;
                    case "Dump":
                        hardware = splitArgs[0];
                        if (components.ContainsKey(hardware))
                        {
                            var hardwareToTransferToDump = components[hardware];
                            components.Remove(hardware);
                            var dump = new Dump(hardwareToTransferToDump);
                            dumpLogs.Add(hardware, dump);
                        }
                        break;
                    case "Restore":
                        hardware = splitArgs[0];
                        if (dumpLogs.ContainsKey(hardware))
                        {
                            var hardwareToTransferToComponents = dumpLogs[hardware].Hardware;
                            dumpLogs.Remove(hardware);
                            components.Add(hardware, hardwareToTransferToComponents);
                        }
                        break;
                    case "Destroy":
                        hardware = splitArgs[0];
                        if (dumpLogs.ContainsKey(hardware))
                        {
                            dumpLogs.Remove(hardware);
                        }
                        break;
                    case "DumpAnalyze":
                        int expressCount = 0;
                        int lightCount = 0;
                        foreach (var dumpLogsValue in dumpLogs.Values)
                        {
                            expressCount += dumpLogsValue.Hardware.Softwares.Count(s => s.GetType().Name == "Express");
                            lightCount += dumpLogsValue.Hardware.Softwares.Count(s => s.GetType().Name == "Light");
                        }
                        Console.WriteLine("Dump Analysis");
                        Console.WriteLine($"Power Hardware Components: {dumpLogs.Count(h => h.Value.Hardware.GetType().Name == "Power")}");
                        Console.WriteLine($"Heavy Hardware Components: {dumpLogs.Count(h => h.Value.Hardware.GetType().Name == "Heavy")}");
                        Console.WriteLine($"Express Software Components: {expressCount}");
                        Console.WriteLine($"Light Software Components: {lightCount}");
                        Console.WriteLine($"Total Dumped Memory: {dumpLogs.Sum(i => i.Value.Hardware.Softwares.Sum(s => s.MemoryConsumption))}");
                        Console.WriteLine($"Total Dumped Capacity: {dumpLogs.Sum(i => i.Value.Hardware.Softwares.Sum(s => s.CapacityConsumption))}");
                        break;
                }
            }
            foreach (var hardWare in components.Values)
            {
                Console.WriteLine(hardWare);
            }
        }
    }
}
