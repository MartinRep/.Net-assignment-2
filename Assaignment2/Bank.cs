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

        public Account findAccount(string name)
        {
            Account mask = new Account(name);
            return accounts.Find(acc => acc.Equals(name));
        }

        public Boolean updateBalance(string name, ref float transaction, out string error)
        {
            Account acc = findAccount(name);
            if (acc == null)
            {
                error = "Account not found!!!";
                return false;
            }
            else
            {
                acc.Balance = acc.Balance + transaction;
                transaction = 0;
                error = "";
                return true;
            }
        }

        public Boolean updateName(ref string name, string newName, out string error)
        {
            Account acc = findAccount(name);
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

        public Boolean createAccount(string name)
        {
            try
            {
                accounts.Add(new Account(name));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public string accDetails(string name)
        {
            Account acc = findAccount(name);
            return (string.Format("Account name: {0} \n Balance: {1}", acc.Name, acc.Balance));
        }

    }
}
