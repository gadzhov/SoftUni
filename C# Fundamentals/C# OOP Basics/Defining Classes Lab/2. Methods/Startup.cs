//namespace _2.Methods
//{

using System;

class Startup
{
    static void Main(string[] args)
    {
        var acc = new BankAccount()
        {
            ID = 1
        };
        acc.Deposit(15);
        acc.Withdraw(5);

        Console.WriteLine(acc.ToString());
    }
}
//}
