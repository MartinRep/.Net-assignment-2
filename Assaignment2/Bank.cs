using System;
using System.Collections.Generic;

namespace Assaignment2
{
    class Bank
    {
        //Collection of accounts in existance
        private List<Account> accounts;

        // Constructor. Initialize the accounts List
        public Bank()
        {
            accounts = new List<Account>();
        }

        // Creates a new account object with name specified and adds the account into accounts Collection.
        // Returns the new account unique number.
        public float CreateAccount(string name)
        {
            Account newAcc = new Account(name);
            accounts.Add(newAcc);
            return newAcc.AccountNum;
        }

        // Look for specific Account object inside accounts List. This is done by Account.class implementing IEquatable interface.
        //Returns Account object or null.
        public Account FindAccount(float accNum)
        {
            return accounts.Find(acc => acc.Equals(accNum));
        }
        // Loops through accounts List and look for specific name. Account number is returned, or better initilized inside this method(out).
        // Returns true if account is found.
        // It is set to 0 if search is unsuccesful and return false.
        public bool AccLookup(string name, out float accNum)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Name.Equals(name))
                {
                    accNum = acc.AccountNum;
                    return true;
                }
            }
            accNum = 0;
            return false;
        }

        // Updates account balance with 'transaction' amount. First it finds the account object and checks for sufficient funds.
        // try and catch is used in case account object with specific account number is not found and null is returned instead.
        // Error message is returned via 'out string error' string.
        public bool UpdateBalance(float accNum, ref float transaction, out string error)
        {
            try
            {
                Account acc = FindAccount(accNum);
                if (acc.Balance + transaction < 0)
                {
                    error = string.Format("Insuficient funds! Cannot withdraw: {0} from balance: {1}", transaction, acc.Balance);
                    return false;
                }
                acc.Balance = acc.Balance + transaction;
                transaction = 0;
                error = "";
                return true;
            }
            catch (NullReferenceException)
            {
                error = "Account not found!!!";
                return false;
            }
        }

        // Updates account name with 'newName'.  First it finds the account object and call Set Name method to modify the name.
        // Returns true if successful or false with appropriate error message.
        public bool UpdateName(float accNum, string newName, out string error)
        {
            try
            {
                FindAccount(accNum).Name = newName;
                error = "";
                return true;
            }
            catch (NullReferenceException)
            {
                error = "Account not found!!!";
                return false;
            }
        }

        // Gets all Account details formatted to 'accDetails' string.  First it finds the account object and call ToString() method on it.
        // try and catch is used in case account object with specific account number is not found and null is returned instead.
        // Returns true if Account is found and details are retrieved.
        // Returns false if account is not found accompanied with appropriate error message.
        public bool AccDetails(float accNum, out string accDetails, out string error)
        {
            try
            {
                accDetails = FindAccount(accNum).ToString();
                error = "";
                return true;
            }
            catch (NullReferenceException)
            {
                accDetails = "";
                error = "Account: " +accNum +" doesn't exist!";
                return false;
            }
        }
    }
}
