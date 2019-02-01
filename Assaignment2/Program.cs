using System;

namespace Assaignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            string error;
            float value = 150;
            int [] accountNumber = new int[255];
            accountNumber[0] = bank.createAccount("Martin 0");
            accountNumber[1] = bank.createAccount("Martin 1");
            accountNumber[2] = bank.createAccount("Martin 2");
            accountNumber[3] = bank.createAccount("Martin the third");

            Console.WriteLine(bank.accDetails(accountNumber[3]));

            Console.WriteLine("Value before ref method call: " + value);
            bank.updateBalance(accountNumber[3], ref value, out error);
            Console.WriteLine("Value after ref method call: " + value);
            Console.WriteLine("Error: " + error);

            bank.updateName(accountNumber[3], "Martin Repicky", out error);
            Console.WriteLine("Error: " + error);
            Console.WriteLine(bank.accDetails(accountNumber[3]));

            accountNumber[10] = bank.accLookup("Martin 2");
            Console.WriteLine(bank.accDetails(accountNumber[10]));

            value = 150;
            bank.updateBalance(accountNumber[10], ref value, out error);
            Console.WriteLine("Error: " + error);
            Console.WriteLine(bank.accDetails(accountNumber[10]));

            value = -200;
            bank.updateBalance(accountNumber[10], ref value, out error);
            Console.WriteLine("Error: " + error);
            Console.WriteLine(bank.accDetails(accountNumber[10]));
        }
    }
}
