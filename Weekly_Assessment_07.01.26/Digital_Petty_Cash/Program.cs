// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //INCOME
        DigitalPettyCash.Ledger<DigitalPettyCash.IncomeTransaction> income = new DigitalPettyCash.Ledger<DigitalPettyCash.IncomeTransaction> ();

        DigitalPettyCash.IncomeTransaction income1 = new DigitalPettyCash.IncomeTransaction();

        income1.Id = 1;
        income1.Date = DateTime.Now;
        income1.Amount = 500;
        income1.Source = "Main Cash";
        income1.Description = "Digital Petty Cash is cash";

        income.AddEntry(income1);

        //EXPENSE - 1
        DigitalPettyCash.Ledger<DigitalPettyCash.ExpenseTransaction> expense = new DigitalPettyCash.Ledger<DigitalPettyCash.ExpenseTransaction>();

        DigitalPettyCash.ExpenseTransaction expense1 = new DigitalPettyCash.ExpenseTransaction();

        expense1.Id = 101;
        expense1.Date = DateTime.Now;
        expense1.Amount = 20;
        expense1.Category = "Stationary";
        expense1.Description = "Notebook";

        //EXPENSE - 2
        DigitalPettyCash.ExpenseTransaction expense2 = new DigitalPettyCash.ExpenseTransaction();

        expense2.Id = 102;
        expense2.Date = DateTime.Now;
        expense2.Amount = 15;
        expense2.Category = "Food";
        expense2.Description = "Lays";

        expense.AddEntry(expense1);
        expense.AddEntry(expense2);

        //CALCULATETOTAL
        double totalIncome = income.CalculateTotal();
        double totalExpense = expense.CalculateTotal();
        double netBalance = totalIncome - totalExpense;

        Console.WriteLine("---- DIGITAL PETTY CASH ----");
        Console.WriteLine("Total Income  : " + totalIncome);
        Console.WriteLine("Total Expense : " + totalExpense);
        Console.WriteLine("Net Balance : " + netBalance);

        //DISPLAY
        Console.WriteLine("------- ALL TRANSACTIONS ---------");
        List<DigitalPettyCash.Transaction> allTransactions = new List<DigitalPettyCash.Transaction>();

        foreach(var t in income.GetAllTransactions())
        {
            allTransactions.Add(t); //adding income
        }

        foreach(var t in expense.GetAllTransactions())
        {
            allTransactions.Add(t); //adding expenses
        }

        foreach(var t in allTransactions)
        {
            Console.WriteLine(t.GetSummary());
        }
        Console.ReadLine();
    }
}