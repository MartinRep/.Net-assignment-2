using System;


namespace Assaignment2
{
    // Model class. Implements IEquatable interface to be able to use .Find() inside FindAccount() method of class Bank.
    // This means you need to implement Equals() method inside this class.
    class Account : IEquatable<Account>
    {
        private volatile static float accounts = 1; //static variable shared with all Account.class instances. Every Account.class instance has unique Account number thanks to this.

        public Account(string name)
        {
            Name = name;
            Balance = 0;
            AccountNum = accounts++;    // AccountNum(instance variable) gets unique number from static(shared) 'accounts' variable.
        }
        // Variables with appropriate getters and setters
        public string Name { get; set; }
        public float Balance { get; set; }
        public float AccountNum { get; }
        public float Accounts { get; }

        // Equals methods implementation for comparison.
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
        //Override of ToString() method. Returns formatted string with variables
        override public string ToString() => string.Format("\n************\nAccount name: {0} \nBalance: {1}\nAccount number: {2}\n************\n", Name, Balance, AccountNum);

    }
}
