namespace PhotoShare.Service.Mocks
{
    public class UserServiceMock : UserService
    {
        public override void Add(string username, string password, string email)
        {
        }

        public override bool IsExistingByUserName(string username)
        {
            return false;
        }
    }
}
