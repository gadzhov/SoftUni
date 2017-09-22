namespace _4._Many_to_Many_Relation
{
    using _4._Many_to_Many_Relation.Data;

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
