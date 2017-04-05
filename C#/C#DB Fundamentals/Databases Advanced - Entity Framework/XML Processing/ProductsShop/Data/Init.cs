namespace Data
{
    public class Init
    {
        public static void Run()
        {
            using (var context = new ProductShopContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
