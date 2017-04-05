namespace PhotoShare.Service.Mocks
{
    public class AddTownServiceMock : TownService
    {
        public override void AddTown(string townName, string countryName)
        {
        }

        public override bool IsTownExisting(string townName)
        {
            return false;
        }
    }
}
