using System;

class Program
{
    public decimal Balance {get; set;}

    public Program(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if(amount < 0)
        {
            throw new Exception("Deposit amount cannot be negative");
        }
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if(amount > Balance)
        {
            throw new Exception("Insufficient funds");
        }
        Balance -= amount;
    }

    static void Main()
    {
        UnitTest obj = new UnitTest();

        Console.WriteLine("Running Deposit Valid Test:");
        obj.Test_Deposit_ValidAmount();
        Console.WriteLine();

        Console.WriteLine("Running Deposit Negative Test:");
        obj.Test_Deposit_NegativeAmount();
        Console.WriteLine();

        Console.WriteLine("Running Withdraw Valid Test:");
        obj.Test_Withdraw_ValidAmount();
        Console.WriteLine();

        Console.WriteLine("Running Withdraw Insufficient Funds Test:");
        obj.Test_Withdraw_InsufficientFunds();
    }    
}