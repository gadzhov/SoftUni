namespace MassDefect.Export
{
    class Startup
    {
        static void Main(string[] args)
        {
            //JsonExport.ExportPlanets();
            //JsonExport.ExportPeople();
            //JsonExport.ExportAnomaly();
            XmlExport.ExportAnomaliesAndTheirVictims();
        }
    }
}
