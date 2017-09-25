namespace BankSystem.Models
{
    using System;
    using BankSystem.Contracts;
    public abstract class Account : IAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Ballance { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public void DepositMoney(decimal money)
        {
            this.Ballance += money;
        }

        public void WithdrawMoney(decimal money)
        {
            if (this.Ballance < money)
            {
                throw new InvalidOperationException("Ballance is not enought!");
            }

            this.Ballance -= money;
        }

        public override string ToString()
        {
            return $"--{this.AccountNumber} {this.Ballance}";
        }
    }
}
