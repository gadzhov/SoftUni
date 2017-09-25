namespace BankSystem.Contracts
{
    public interface IAccount
    {
        int Id { get; }

        string AccountNumber { get; }

        decimal Ballance { get; }
    }
}
