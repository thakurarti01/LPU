using System;
using System.Collections.Generic;
using System.Linq;
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message){}
}

class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message){}
}

class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base (message){}
}

public abstract class BankAccount
{
    public string AccountNumber{get; set;}
    public string CustomerName {get; set;}
    public double Balance {get; set;}

    protected BankAccount(string accNo, string custName, double bal)
    {
        AccountNumber = accNo;
        CustomerName = custName;
        Balance = bal;
    }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
        // return Balance;
    }
    public virtual void Withdraw(double amount)
    {
        if(Balance < amount)
        {
            throw new InsufficientBalanceException("Insufficient Balance");
        }
        Balance -= amount;
    }
    public abstract double CalculateInterest();
}

class SavingsAccount : BankAccount
{
    private const double minBalance = 1000;
    private const double interestRate = 0.04;

    public SavingsAccount(string accNo, string custName, double bal) : base(accNo, custName, bal){}

    public override void Deposit(double amount)
    {
        base.Deposit(amount);
    }
    public override void Withdraw(double amount)
    {
        if(Balance - amount < minBalance)
        {
            throw new MinimumBalanceException("Minimum balance should be maintained");
        }
        base.Withdraw(amount);
    }

    public override double CalculateInterest()
    {
        return Balance * interestRate;
    }
    
}

class CurrentAccount : BankAccount
{
    private const double overdraftLimit = 20000;

    public CurrentAccount(string accNo, string custName, double bal) : base(accNo, custName, bal){}
    public override void Withdraw(double amount)
    {
        if(amount > overdraftLimit + Balance)
        {
            throw new InvalidTransactionException("overdraft amount exceeded");
        }
        Balance -= amount; //we didn't call base.Withdraw(amount) method because in base class we are allowed to withdraw amount less than balance but here we can withdraw balance upto overdraft limit that's why we completely overide this thing
    }

    public override double CalculateInterest()
    {
        return 0;
    }
}

class LoanAccount : BankAccount
{
    private const double interestRate = 0.10;

    public LoanAccount(string accNo, string custName, double bal) : base(accNo, custName, bal){}

    public override void Deposit(double amount)
    {
        throw new InvalidTransactionException("Can't deposit in Loan account");
    }

    public override double CalculateInterest()
    {
        return Balance * interestRate;
    }

}