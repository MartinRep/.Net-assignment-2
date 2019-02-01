using System;
using System.Collections.Generic;
using System.Text;

namespace Assaignment2
{
    class Bank
    {
        private List<Account> accounts;


        public Bank()
        {
            accounts = new List<Account>();
        }

        public Account findAccount(int accNum)
        {
            Account mask = new Account(accNum);
            return accounts.Find(acc => acc.Equals(accNum));
        }

        public Boolean updateBalance(int accNum, ref float transaction, out string error)
        {
            Account acc = findAccount(accNum);
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

        public Boolean updateName(int accNum, string newName, out string error)
        {
            Account acc = findAccount(accNum);
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

        public int createAccount(string name)
        {
            Account newAcc = new Account(name);
            accounts.Add(newAcc);
            return newAcc.AccountNum;
        }

        public string accDetails(int accNum)
        {
            Account acc = findAccount(accNum);
            try
            {
            return (string.Format("Account name: {0} \nBalance: {1}\nAccount number: {2}", acc.Name, acc.Balance, acc.AccountNum));
            }
            catch (NullReferenceException)
            {
            return "Account: " +accNum +" doesn't exist!";
            }
        }

        public int accLookup(string name)
        {
            foreach (Account acc in accounts)
            {
                if(acc.Name.Equals(name))
                {
                    return acc.AccountNum;
                }
            }
            return 0;
        }

    }
}
