using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
         BankOperations bank = new BankOperations();

        while (true)
        {
            Console.WriteLine("Enter your request:");
            string msg = Console.ReadLine();

            decimal balance = bank.ProcessOperation(msg);

            Console.WriteLine("Current Balance: " + balance);
        }
    }
}