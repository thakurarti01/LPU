using System;

class UnitTest
{
    public void Test_Deposit_ValidAmount()
    {
        Program p = new Program(1000);
        p.Deposit(500);

        if(p.Balance == 1500)
        {
            Console.WriteLine("Deposit successful");
        }
        else
        {
            Console.WriteLine("Deposit failed");
        }
    }

    public void Test_Deposit_NegativeAmount()
    {
        Program p = new Program(1000);
        try
        {
            p.Deposit(-500);
            Console.WriteLine("Test failed");
        }
        catch(Exception ex)
        {
            if(ex.Message == "Deposit amount cannot be negative")
            {
                Console.WriteLine("Negative deposit test passed");
            }
            else
            {
                Console.WriteLine("Wrong error message");
            }
        }
    }

    public void Test_Withdraw_ValidAmount()
    {
        Program p = new Program(1000);
        p.Withdraw(500);

        if(p.Balance == 500)
        {
            Console.WriteLine("Withdraw test passed");
        }
        else
        {
            Console.WriteLine("Withdraw test failed");
        }
    }

    public void Test_Withdraw_InsufficientFunds()
    {
        Program p = new Program(1000);
        try
        {
            p.Withdraw(1500);
            Console.WriteLine("Test failed");
        }
        catch(Exception ex)
        {
            if(ex.Message == "Insufficient funds")
            {
                Console.WriteLine("Exceeding withdraw test passed");
            }
            else
            {
                Console.WriteLine("Exceeding withdraw test failed");
            }
        }

    }
    
}