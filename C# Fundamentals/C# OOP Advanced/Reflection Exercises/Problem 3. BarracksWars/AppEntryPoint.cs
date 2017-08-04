using Problem_3.BarracksWars.Contracts;
using Problem_3.BarracksWars.Core;
using Problem_3.BarracksWars.Core.Factories;
using Problem_3.BarracksWars.Data;

namespace Problem_3.BarracksWars
{
    public class AppEntryPoint
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
