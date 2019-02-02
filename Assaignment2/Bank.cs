using System;
using System.Collections.Generic;

namespace Assaignment2
{
    class Bank
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
        }

        public float CreateAccount(string name)
        {
            Account newAcc = new Account(name);
            accounts.Add(newAcc);
            return newAcc.AccountNum;
        }

        public Account FindAccount(float accNum)
        {
            return accounts.Find(acc => acc.Equals(accNum));
        }

        public bool AccLookup(string name, ref float accNum)
        {
            foreach (Account acc in accounts)
            {
                if (acc.Name.Equals(name))
                {
                    accNum = acc.AccountNum;
                    return true;
                }
            }
            return false;
        }

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

        public bool AccDetails(float accNum, ref string accDetails, out string error)
        {
            try
            {
                accDetails = FindAccount(accNum).ToString();
                error = "";
                return true;
            }
            catch (NullReferenceException)
            {
                error = "Account: " +accNum +" doesn't exist!";
                return false;
            }
        }
    }
}
