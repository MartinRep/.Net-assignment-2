using System;

namespace Assaignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            float lodgement, withdraw;
            Bank bank = new Bank();
            float [] accountNumber = new float[4];

            accountNumber[0] = bank.CreateAccount("Current Account");
            accountNumber[1] = bank.CreateAccount("Joint Account");
            accountNumber[2] = bank.CreateAccount("Savings Account");
            accountNumber[3] = bank.CreateAccount("Morgage");

            Console.WriteLine(AccDetails(bank, accountNumber[3]));
            lodgement = 150;
            Console.WriteLine("Value before ref method call: " + lodgement);
            UpdateBalance(bank, accountNumber[3], ref lodgement);
            Console.WriteLine("Value after ref method call: " + lodgement);
            Console.WriteLine(AccDetails(bank, accountNumber[3]));

            Console.WriteLine(UpdateName(bank, accountNumber[3], "Loan"));
            Console.WriteLine(AccLookup(bank, "Morgage"));

            Console.WriteLine(AccLookup(bank, "Current Account"));

            lodgement = 100;
            Console.WriteLine(UpdateBalance(bank, accountNumber[0], ref lodgement));

            withdraw = -200;
            Console.WriteLine(UpdateBalance(bank, accountNumber[0], ref withdraw));
        }

        private static string AccLookup(Bank bank, string accName)
        {
            float accSearch = 0;
            if (bank.AccLookup(accName, ref accSearch))
            {
                return AccDetails(bank, accSearch);
            }
            else return "Error: Account " + accName + " Not Found!!!";
        }
        private static string AccDetails(Bank bank, float accNum)
        {
            string accDetails = "";
            if (bank.AccDetails(accNum, ref accDetails, out string error)) return accDetails;
            else return "Error: " + error;
        }

        private static string UpdateBalance( Bank bank, float accNum, ref float value)
        {
            if (bank.UpdateBalance(accNum, ref value, out string error))
            {
                return AccDetails(bank, accNum);
            }
            return "Error: " + error;
        }

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
