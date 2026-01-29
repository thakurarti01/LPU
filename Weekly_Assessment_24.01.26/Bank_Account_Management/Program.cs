using System;
namespace BankSys
{
    public class Account
    {
        // TODO: Add private fields
        private string name;
        private double balance;
        
        // TODO: Implement constructor
        public Account(string name, double initialBalance)
        {
            this.name = name;
            this.balance = initialBalance;
        }
        
        // TODO: Implement deposit method
        public double deposit(double amount)
        {
            balance += amount;
            return balance;
        }
        
        // TODO: Implement getBalance method
        public double getBalance()
        {
            return balance;
        } 
        
        // TODO: Implement setName method
        public void setName(string newName)
        {
            name = newName;
        }
        
        // TODO: Implement getName method
        public string getName()
        {
            return name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test your implementation here
            Account account1 = new Account("Alok Mittal", 1250.00);
            Console.WriteLine(account1.getBalance());
            Account account2 = new Account("John Doe", 500);
            Console.WriteLine(account2.getName());
            Console.WriteLine(account2.getBalance());
            Account account3 = new Account("Riya Amit Mehta ", 1250);
            Console.WriteLine(account3.deposit(0.5));
            Console.WriteLine(account3.getBalance());

            Console.WriteLine(account3.getName());
        }
    }
}