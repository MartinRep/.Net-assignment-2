using System;
using System.Collections.Generic;
using System.Text;

namespace Assaignment2
{
    class Account : IEquatable<Account>
    {
        private string name;
        private float balance;
        private static int accNumber = 0;

        public Account(string name)
        {
            this.name = name;
            balance = 0;
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

        public bool Equals(Account other)
        {
            return (name.Equals(other.Name) && balance.Equals(other.Balance));
        }

        public bool Equals(string name)
        {
            return name.Equals(Name);
        }
    }
}
