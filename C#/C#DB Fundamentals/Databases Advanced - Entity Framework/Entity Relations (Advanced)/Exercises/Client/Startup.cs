using Exercises.Data;

namespace Exercises
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var context = new ExercisesContext();
            context.Database.Initialize(true);
        }
    }
}
