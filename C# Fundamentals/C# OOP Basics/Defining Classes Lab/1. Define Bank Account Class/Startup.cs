using System;

//namespace _1.Define_Bank_Account_Class
//{
    class Startup
    {
        static void Main(string[] args)
        {
            var acc = new BankAccount()
            {
                ID = 1,
                Balance = 15
            };

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
//}
