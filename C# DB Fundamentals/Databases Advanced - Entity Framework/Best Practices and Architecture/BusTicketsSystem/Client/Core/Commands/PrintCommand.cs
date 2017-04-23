using Services;

namespace Client.Core.Commands
{
    public class PrintCommand
    {
        private readonly BusService _busService;

        public PrintCommand(BusService busService)
        {
            this._busService = busService;
        }
        public void Execute(string[] data)
        {
            var busId = int.Parse(data[0]);
            this._busService.PrintInfo(busId);
        }
    }
}
