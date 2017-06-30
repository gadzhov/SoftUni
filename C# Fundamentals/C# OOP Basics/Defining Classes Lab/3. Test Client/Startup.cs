using System;
using System.Collections.Generic;

namespace _3.Test_Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var cmdTokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var cmdTye = cmdTokens[0];
                switch (cmdTye)
                {
                    case "Create":
                        Create(cmdTokens, accounts);
                        break;
                    case "Deposit":
                        Deposit(cmdTokens, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(cmdTokens, accounts);
                        break;
                    case "Print":
                        Print(cmdTokens, accounts);
                        break;
                }
            }
        }

        private static void Print(string[] cmdTokens, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdTokens[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id].ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] cmdTokens, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdTokens[1]);
            var amount = double.Parse(cmdTokens[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] cmdTokens, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdTokens[1]);
            var amount = double.Parse(cmdTokens[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] cmdTokens, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdTokens[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount()
                {
                    ID = id
                };
                accounts.Add(id, acc);
            }
        }
    }
}
