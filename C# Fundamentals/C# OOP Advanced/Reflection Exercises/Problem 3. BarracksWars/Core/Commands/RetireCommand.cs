using Problem_3.BarracksWars.Contracts;

namespace Problem_3.BarracksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            base.Repository.RemoveUnit(base.Data[1]);
            var output = $"{base.Data[1]} retired!";

            return output;
;        }
    }
}
