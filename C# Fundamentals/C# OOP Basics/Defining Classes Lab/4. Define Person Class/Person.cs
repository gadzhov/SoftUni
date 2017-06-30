using System.Collections.Generic;
using System.Linq;

//namespace _4.Define_Person_Class
//{
    class Person
    {
        private string _name;
        private int _age;
        private List<BankAccount> _accounts;

        public Person(string name, int age) : this(name, age, new List<BankAccount>())
        {
        }

        public Person(string name, int age, List<BankAccount> accounts)
        {
            this._name = name;
            this._age = age;
            this._accounts = accounts;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<BankAccount> Accounts { get; set; }

        public double GetBalance()
        {
            return this.Accounts.Sum(b => b.Balance);
        }
    }
//}
