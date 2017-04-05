namespace MassDefect.Data
{
    public static class Utility
    {
        public static void InitDB()
        {
            using (var context = new MassDefectContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
