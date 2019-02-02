using System;

namespace Assaignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            float lodgement, withdraw;  // Variables for testing BalanceUpdate
            Bank bank = new Bank();     // Initialization of Bank object. The idea is there can be many Bank objects
            float [] accountNumber = new float[4];  //Collection of some test accounts
            
            //Initialization of test accounts
            accountNumber[0] = bank.CreateAccount("Current Account");
            accountNumber[1] = bank.CreateAccount("Joint Account");
            accountNumber[2] = bank.CreateAccount("Savings Account");
            accountNumber[3] = bank.CreateAccount("Morgage");
            
            // Account details
            Console.WriteLine(AccDetails(bank, accountNumber[3]));
            
            // This demonstrate how variable 'lodgement' is changed inside UpdateBalance method and effectivelly here as well via keyword 'ref'
            lodgement = 150;
            Console.WriteLine("Value before method with ref variable called: " + lodgement);
            UpdateBalance(bank, accountNumber[3], ref lodgement);
            Console.WriteLine("Value after method with ref variable called: " + lodgement);
            Console.WriteLine(AccDetails(bank, accountNumber[3]));
            
            // Change account name. If successful returns account.ToString(), else Error message
            Console.WriteLine(UpdateName(bank, accountNumber[3], "Loan"));
            
            // This shows, that there's no account with name Morgage, at it was renamed to 'Loan'
            Console.WriteLine(AccLookup(bank, "Morgage"));
            
            // AccLookup method look for account with specific name. 
            Console.WriteLine(AccLookup(bank, "Current Account"));
            
            // UpdateBalance on account test(Lodgement). This demonstrates how to change value of account balance.
            lodgement = 100;
            Console.WriteLine(UpdateBalance(bank, accountNumber[0], ref lodgement));
            
            // // UpdateBalance on account test(Withdraw). This demonstrate implementation of business logic inside Bank class. You can't withdraw more then there is in the account.
            withdraw = -200;
            Console.WriteLine(UpdateBalance(bank, accountNumber[0], ref withdraw));
        }

        // Abstraction of an Account lookup. Usefull, if you want to change functionality, you do it in one place.
        private static string AccLookup(Bank bank, string accName)
        {
            if (bank.AccLookup(accName, out float accSearch))
            {
                return AccDetails(bank, accSearch);
            }
            else return "Error: Account " + accName + " Not Found!!!";
        }
        //Abstraction of an Account Details. 
        private static string AccDetails(Bank bank, float accNum)
        {
            if (bank.AccDetails(accNum, out string accDetails, out string error)) return accDetails;
            else return "Error: " + error;
        }

        //Abstraction of Update Balance on an account.
        private static string UpdateBalance( Bank bank, float accNum, ref float value)
        {
            if (bank.UpdateBalance(accNum, ref value, out string error))
            {
                return AccDetails(bank, accNum);
            }
            return "Error: " + error;
        }

        //Abstraction of Update name of a account.
        private static string UpdateName(Bank bank, float accNum, string newName)
        {
            if (bank.UpdateName(accNum, newName, out string error))
            {
                return AccDetails(bank, accNum);
            }
            else return "Error: " + error;
        }
    }
}
