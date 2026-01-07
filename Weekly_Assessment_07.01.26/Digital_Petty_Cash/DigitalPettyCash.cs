using System;
using System.Collections;
using System.Collections.Generic;

class DigitalPettyCash
{
    public interface IReportable
    {
        string GetSummary();
    }

    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public abstract string GetSummary();
    }

    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }

        public override string GetSummary()
        {
            return "Expense : " + Amount + " || Category: " + Category;
        }
    }

    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }

        public override string GetSummary()
        {
            return "Income : " + Amount;
        }
    }

    public class Ledger<T> where T : Transaction
    {
        private List<T> transactions = new List<T>();

        public void AddEntry(T entry)
        {
            transactions.Add(entry);
        }

        public List<T> GetTransactionsByDate(DateTime date)
        {
            List<T> result = new List<T>();

            foreach (T transaction in transactions)
            {
                if(transaction.Date == date)
                {
                    result.Add(transaction);
                }
            }
            return result;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (T transaction in transactions)
            {
                total += transaction.Amount; 
            }
            return total;
        }

        public List<T> GetAllTransactions()
        {
            return transactions;
        }
    }
}
