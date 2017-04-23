using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MassDefect.Data.Store;

namespace MassDefect.Export
{
    public static class XmlExport
    {
        public static void ExportAnomaliesAndTheirVictims()
        {
            var anomalies = AnomalyStore.GetAnomaliesWithTheirVictims();
            var xmlDoc = new XDocument();
            
            var xmlEle = new XElement("anomalies", anomalies.Select(a => 
                new XElement("anomaly", new XAttribute("id", a.Id), new XAttribute("origin-planet", a.OriginPlanet), new XAttribute("teleport-planet", a.TeleportPlanet),
                    new XElement("victims",
                        a.Victims.Select(v => 
                        new XElement("victim", new XAttribute("name", v.Name)))))));

            xmlDoc.Add(xmlEle);

            xmlDoc.Save("../../../exports/anomalies.xml");
        }
    }
}
