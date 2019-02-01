using System;
using System.Collections.Generic;
using System.Text;

namespace Assaignment2
{
    class Account : IEquatable<Account>
    {
        private string name;
        private float balance;
        private volatile static int accNum = 1;
        private int accountNumber;

        public Account (int accNum)
        {
            Name = "Search only account";
            balance = 0;
            accountNumber = accNum;
        }

        public Account(string name)
        {
            this.name = name;
            balance = 0;
            accountNumber = accNum++;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public float Balance
        {
            get => balance;
            set => balance = value;
        }

        public int AccountNum
        {
            get => accountNumber;
        }

        public bool Equals(Account other)
        {
            return (name.Equals(other.Name) && balance.Equals(other.Balance) && accountNumber.Equals(other.AccountNum));
        }

        public bool Equals(int accNum)
        {
            return accNum.Equals(AccountNum);
        }

        public bool Equals(string name)
        {
            return name.Equals(Name);
        }
    }
}
