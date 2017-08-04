using Problem_3.BarracksWars.Contracts;

namespace Problem_3.BarracksWars.Core.Commands
{
    public class ReportCommand : Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = base.Repository.Statistics;
            return output;
        }
    }
}
