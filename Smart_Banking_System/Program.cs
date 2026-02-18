using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("S101", "Ravi", 60000),
            new CurrentAccount("S102", "Ayush", 45000),
            new LoanAccount("S103", "Neha", 50000),
            new SavingsAccount("S104", "Radha", 30000),
            new CurrentAccount("S105", "Alok", 85000)
        };

        var highBalance = accounts.Where(n => n.Balance > 50000);
        var totalBalance = accounts.Sum(n => n.Balance);
        var top3Balance = accounts.OrderByDescending(n => n.Balance).Take(3);
        var accountType = accounts.GroupBy(n => n.GetType().Name);
        var nameStartWithR = accounts.Where(n => n.CustomerName.StartsWith("R"));

        Console.WriteLine("Accounts with Balance > 50000:");
        foreach (var acc in highBalance)
            Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");

        Console.WriteLine("\nTotal Bank Balance:");
        Console.WriteLine(totalBalance);

        Console.WriteLine("\nTop 3 Highest Balance Accounts:");
        foreach (var acc in top3Balance)
            Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");

        Console.WriteLine("\nAccounts Grouped By Type:");
        foreach (var group in accountType)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var acc in group)
                Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");
        }

        Console.WriteLine("\nCustomers Whose Name Starts With R:");
        foreach (var acc in nameStartWithR)
            Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");
    }
}