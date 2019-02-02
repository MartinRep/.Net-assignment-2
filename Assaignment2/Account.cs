using System;


namespace Assaignment2
{
    class Account : IEquatable<Account>
    {
        private volatile static float accounts = 1;

        public Account(string name)
        {
            Name = name;
            Balance = 0;
            AccountNum = accounts++;
        }
        public string Name { get; set; }
        public float Balance { get; set; }
        public float AccountNum { get; }
        public float Accounts { get; }

        public bool Equals(Account other)
        {
            return (Name.Equals(other.Name) && Balance.Equals(other.Balance) && AccountNum.Equals(other.AccountNum));
        }

        public bool Equals(float accNum)
        {
            return accNum.Equals(AccountNum);
        }

        public bool Equals(string name)
        {
            return name.Equals(Name);
        }

        override public string ToString() => string.Format("\n************\nAccount name: {0} \nBalance: {1}\nAccount number: {2}\n************\n", Name, Balance, AccountNum);

    }
}
