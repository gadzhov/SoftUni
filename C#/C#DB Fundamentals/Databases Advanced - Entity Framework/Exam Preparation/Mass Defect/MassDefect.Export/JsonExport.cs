using System.IO;
using System.Linq;
using MassDefect.Data;
using MassDefect.Data.Store;
using Newtonsoft.Json;

namespace MassDefect.Export
{
    public static class JsonExport
    {
        public static void ExportPlanets()
        {
            var planets = PlanetsStore.GetPlanetsWithNoVictims();
            var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

            File.WriteAllText("../../../exports/planets.json", json);
        }

        public static void ExportPeople()
        {
            var people = PeopleStore.GetPeopleWichHaveNotBeenVictimsOfAnomalies();
            var json = JsonConvert.SerializeObject(people, Formatting.Indented);

            File.WriteAllText("../../../exports/people.json", json);
        }

        public static void ExportAnomaly()
        {
            var anomaly = AnomalyStore.GetAnomalyWichAffectedTheMostPeople();
            var json = JsonConvert.SerializeObject(anomaly, Formatting.Indented);

            File.WriteAllText("../../../exports/anomaly.json", json);
        }
    }
}
