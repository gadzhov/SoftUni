//namespace _2.Methods
//{
    class BankAccount
    {
        private int id;
        private double balance;

        public int ID { get; set; }
        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {this.ID}, balance {this.Balance}";
        }
    }
//}
