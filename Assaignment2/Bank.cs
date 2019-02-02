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

        public int CreateAccount(string name)
        {
            Account newAcc = new Account(name);
            accounts.Add(newAcc);
            return newAcc.AccountNum;
        }

        public Account FindAccount(int accNum)
        {
            return accounts.Find(acc => acc.Equals(accNum));
        }

        public bool AccLookup(string name, ref int accNum)
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

        public bool UpdateBalance(int accNum, ref float transaction, out string error)
        {
            Account acc = FindAccount(accNum);
            if (acc == null)
            {
                error = "Account not found!!!";
                return false;
            }
            else
            {
                if(acc.Balance + transaction < 0)
                {
                    error = "Insuficient funds!!!";
                    return false;
                }
                acc.Balance = acc.Balance + transaction;
                transaction = 0;
                error = "";
                return true;
            }
        }

        public bool UpdateName(int accNum, string newName, out string error)
        {
            Account acc = FindAccount(accNum);
            if (acc == null)
            {
                error = "Account not found!!!";
                return false;
            }
            else
            {
                acc.Name = newName;
                error = "";
                return true;
            }
        }

        public bool AccDetails(int accNum, ref string accDetails, out string error)
        {
            Account acc = FindAccount(accNum);
            try
            {
                accDetails = acc.ToString();
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
