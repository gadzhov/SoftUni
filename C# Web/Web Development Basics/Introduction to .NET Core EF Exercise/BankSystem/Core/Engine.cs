namespace BankSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using BankSystem.Data;
    using BankSystem.Models;
    using BankSystem.Utilities;

    public class Engine
    {
        private BankSystemController bankSystemController;

        public Engine(BankSystemController bankSystemController)
        {
            this.bankSystemController = bankSystemController;
        }

        public void Run()
        {
            using (BankSystemContext context = new BankSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                string input;
                while ((input = Console.ReadLine()) != "Exit")
                {
                    string[] inputArgs = input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string command = inputArgs[0];
                    string[] args = inputArgs.Skip(1).ToArray();

                    Type type = typeof(Engine);
                    ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(BankSystemController) });
                    Engine engine = ctor.Invoke(new object[] { this.bankSystemController }) as Engine;
                    MethodInfo method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (method == null)
                    {
                        Console.WriteLine("Invalid command!");
                        continue;
                    }
                    method.Invoke(engine, new object[] { context, args });
                }
            }
        }
        /// <summary>
        /// Register user to the database
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Register(BankSystemContext context, string[] args)
        {
            // •	Register <username> <password> <email> 
            string username = args[0];
            string password = args[1];
            string email = args[2];

            if (context.Users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username is taken!");
                return;
            }
            Regex regex = new Regex("^[^\\d]([A-Za-z0-9]+){3}$");
            if (!regex.IsMatch(username))
            {
                Console.WriteLine("Incorrect username!");
                return;
            }
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            {
                Console.WriteLine("Incorrect password!");
                return;
            }
            regex = new Regex("^[^_.-].+[^_.-]@\\w+.\\w+$");
            if (!regex.IsMatch(email))
            {
                Console.WriteLine("Incorrect email!");
                return;
            }

            User user = new User
            {
                Username = username,
                Password = password,
                EmailAddress = email
            };

            context.Users.Add(user);

            context.SaveChanges();

            Console.WriteLine($"{user.Username} was registered in the system.");
        }

        /// <summary>
        /// That command set the current logged in user if exists.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Login(BankSystemContext context, string[] args)
        {
            //•	Login <username> <password> 
            string username = args[0];
            string password = args[1];

            User user = context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.Password == password)
            {
                this.bankSystemController.LogedUser = user;
                Console.WriteLine($"Succesfully logged in {user.Username}");
                return;
            }

            Console.WriteLine("Invalid username / password");
        }


        /// <summary>
        /// Log out the user from the system. If there is no logged in user print appropriate message.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Logout(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("Cannot log out. No user was logged in.");
                return;
            }

            string logedUsername = this.bankSystemController.LogedUser.Username;
            this.bankSystemController.LogedUser = default(User);
            Console.WriteLine($"User {logedUsername} successfully logged out");
        }


        /// <summary>
        /// Add account to currently logged in user.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Add(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine($"You should Login first!");
                return;
            }
            string acountType = args[0];
            decimal initialBallance = decimal.Parse(args[1]);
            Account account = default(Account);
            switch (acountType)
            {
                case "SavingsAccount":
                    double rate = double.Parse(args[2]);
                    account = new SavingAccount
                    {
                        Ballance = initialBallance,
                        AccountNumber = RandomCombinationGenerator.Generate(),
                        Rate = rate
                    };
                    break;
                case "CheckingAccount":
                    double fee = double.Parse(args[2]);
                    account = new CheckingAccount
                    {
                        Ballance =  initialBallance,
                        AccountNumber = RandomCombinationGenerator.Generate(),
                        Fee = fee
                    };
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    return;
            }

            this.bankSystemController.LogedUser.Accounts.Add(account);
            context.Users.Find(this.bankSystemController.LogedUser.Id).Accounts.Add(account);

            context.SaveChanges();

            Console.WriteLine($"Succesfully added account with number {account.AccountNumber}");
        }

        /// <summary>
        /// Prints a list of overall information for all accounts of currently logged in user .
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void ListAccounts(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("You should Login first!");
                return;
            }
            int userId = this.bankSystemController.LogedUser.Id;
            
            List<CheckingAccount> checkingAccounts = context
                .CheckingAccounts
                .Where(ca => ca.OwnerId == userId)
                .ToList();

            List<SavingAccount> savingAccounts = context
                .SavingAccounts
                .Where(sa => sa.OwnerId == userId)
                .ToList();

            //TODO: Sort by count of accounts
            Console.WriteLine($"Accounts for user {this.bankSystemController.LogedUser}");
            Console.WriteLine("Saving Accounts:");
            Console.WriteLine($"{string.Join("\r\n", savingAccounts)}");
            Console.WriteLine("Cheking Accounts:");
            Console.WriteLine($"{string.Join("\r\n", checkingAccounts)}");
        }

        /// <summary>
        /// Adds money to the account with given number
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Deposit(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("You should Login first!");
                return;
            }
            //•	Deposit <Account number> <money> 
            string accountNumber = args[0];
            decimal money = decimal.Parse(args[1]);
            Account account =
                context
                    .Accounts
                    .FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            context.SaveChanges();

            Console.WriteLine($"Account {account.AccountNumber} has balance of {account.Ballance}");
        }

        /// <summary>
        /// Subtracts money from the account with given number
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Withdraw(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("You should Login first!");
                return;
            }

            //•	Withdraw <Account number> <money> 
            string accountNumber = args[0];
            decimal money = decimal.Parse(args[1]);

            Account account = context
                .Accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            account.WithdrawMoney(money);
            context.SaveChanges();

            Console.WriteLine($"Account {account.AccountNumber} has balance of {account.Ballance}");
        }

        /// <summary>
        /// Deduct the fee from the balance of the account with given number
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void DeductFee(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("You should Login first!");
                return;
            }

            // •	DeductFee <Account number> 
            string accountNumber = args[0];

            if (!(context
                .Accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber) is CheckingAccount account))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            account.DeductFee();
            context.SaveChanges();

            Console.WriteLine($"Deducted fee of {account.AccountNumber}. Current balance: {account.Ballance:F2}");
        }

        /// <summary>
        /// Add interest to the balance of the account with given number
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void AddInterest(BankSystemContext context, string[] args)
        {
            if (this.bankSystemController.LogedUser == null)
            {
                Console.WriteLine("You should Login first!");
                return;
            }

            //•	AddInterest <Account number>
            string accountNumber = args[0];
            SavingAccount account = context
                .SavingAccounts
                .FirstOrDefault(sa => sa.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            account.AddRate();
            context.SaveChanges();

            Console.WriteLine($"Added interest to {account.AccountNumber}. Current balance: {account.Ballance:F2}");
        }

        /// <summary>
        /// Terminate the program.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="args"></param>
        private void Exit(BankSystemContext context, string[] args)
        {
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }
    }
}
