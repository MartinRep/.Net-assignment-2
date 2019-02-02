using System;

namespace Assaignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string error;
            float lodgement, withdraw;
            Bank bank = new Bank();
            int [] accountNumber = new int[255];
            string accDetails = "";

            accountNumber[0] = bank.CreateAccount("Martin 0");
            accountNumber[1] = bank.CreateAccount("Martin 1");
            accountNumber[2] = bank.CreateAccount("Martin 2");
            accountNumber[3] = bank.CreateAccount("Martin the third");

            if (bank.AccDetails(accountNumber[3], ref accDetails, out error)) Console.WriteLine(accDetails);
            else Console.WriteLine("Error: " + error);

            lodgement = 150;
            Console.WriteLine("Value before ref method call: " + lodgement);
            if(bank.UpdateBalance(accountNumber[3], ref lodgement, out error)) Console.WriteLine("Value after ref method call: " + lodgement);
            else Console.WriteLine("Error: " + error);

            if(bank.UpdateName(accountNumber[3], "Martin Repicky", out error))
            {
                if (bank.AccDetails(accountNumber[3], ref accDetails, out error)) Console.WriteLine(accDetails);
                else Console.WriteLine("Error: " + error);
            }
            else Console.WriteLine("Error: " + error);

            if (bank.AccLookup("Martin 2", ref accountNumber[10]))
            {
                if (bank.AccDetails(accountNumber[10], ref accDetails, out error)) Console.WriteLine(accDetails);
                else Console.WriteLine("Error: " + error);
            }
            else Console.WriteLine("Error: " + error);

            lodgement = 100;
            if (bank.UpdateBalance(accountNumber[10], ref lodgement, out error))
            {
                if (bank.AccDetails(accountNumber[10], ref accDetails, out error)) Console.WriteLine(accDetails);
                else Console.WriteLine("Error: " + error);
            }
            else Console.WriteLine("Error: " + error);

            withdraw = -200;
            if(bank.UpdateBalance(accountNumber[10], ref withdraw, out error))
            {
                if (bank.AccDetails(accountNumber[10], ref accDetails, out error)) Console.WriteLine(accDetails);
                else Console.WriteLine("Error: " + error);
            }
            else Console.WriteLine("Error: " + error);
        }
    }
}
