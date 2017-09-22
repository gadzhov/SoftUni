namespace _3._Self_Referenced_Table
{
    using _3._Self_Referenced_Table.Data;

    public class Startup
    {
        public static void Main()
        {
            Entity context = new Entity();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
