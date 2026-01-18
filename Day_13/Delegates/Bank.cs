using System;

public class Bank
{
    public double Balance { get; private set; }

    // Delegate variable
    public TransactionHandler OnTransaction;

    public Bank(double initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        OnTransaction?.Invoke($"Deposited ₹{amount}. Current Balance: ₹{Balance}");
    }

    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            OnTransaction?.Invoke("Insufficient Balance!");
        }
        else
        {
            Balance -= amount;
            OnTransaction?.Invoke($"Withdrawn ₹{amount}. Current Balance: ₹{Balance}");
        }
    }
}
