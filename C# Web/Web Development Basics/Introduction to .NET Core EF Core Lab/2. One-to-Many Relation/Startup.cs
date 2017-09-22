namespace _2._One_to_Many_Relation
{
    using _2._One_to_Many_Relation.Data;

    public class Startup
    {
        public static void Main()
        {
            DbContext dbContext = new DbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
