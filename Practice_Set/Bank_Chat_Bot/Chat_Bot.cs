using System;
using System.Collections.Generic;

public interface IBankAccountOperation
{
    decimal Deposit(decimal d);
    decimal Withdraw(decimal d);
    decimal ProcessOperation(string msg);
}

public class BankOperations : IBankAccountOperation
{
    decimal initialBalance = 0;

    public decimal Deposit(decimal d)
    {
        initialBalance =  initialBalance+d;
        return initialBalance;
    }

    public decimal Withdraw(decimal d)
    {
        if(d>initialBalance)
        {
            return initialBalance;
        }
        initialBalance = initialBalance-d;
        return initialBalance;
    }

    public decimal ProcessOperation(string msg)
    {
        msg = msg.ToLower();

        if(msg.Contains("see") || msg.Contains("show"))
        {
            return initialBalance;
        }

        else if(msg.Contains("deposit") || msg.Contains("put") || msg.Contains("invest") || msg.Contains("transfer"))
        {
            decimal amount = ExtractAmount(msg);
            return Deposit(amount);
        }

        else if(msg.Contains("withdraw") || msg.Contains("pull"))
        {
            decimal amount = ExtractAmount(msg);
            return Withdraw(amount);
        }

        else
        {
            return initialBalance;
        }
    }

    private decimal ExtractAmount(string msg)
    {
        string[] parts = msg.Split(' ');
        foreach(string part in parts)
        {
            if(decimal.TryParse(part, out decimal amount))
            {
                return amount;
            }
        }
        return 0;
    }
}