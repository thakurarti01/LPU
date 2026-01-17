using System;

class InsufficientWalletBalanceException : Exception
{
    public InsufficientWalletBalanceException(string message) : base (message)
    {}
}
class Program
{
    public EcommerceShop MakePayment(string name, double balance, double amount)
    {
        EcommerceShop ecomObj = new EcommerceShop();
        ecomObj.UserName = name;
        ecomObj.WalletBalance = balance;
        ecomObj.TotalPurchaseAmount = amount;

        if(amount>balance)
        {
            throw new InsufficientWalletBalanceException("Insufficient balance in your digital wallet");
        }
        Console.WriteLine("Order received!");
        return ecomObj;
    }

    static void Main()
    {
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Balance");
        double balance = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Amount:");
        double amount = Convert.ToDouble(Console.ReadLine());

        Program program = new Program();

        try
        {
            program.MakePayment(name, balance, amount);
        }
        catch(InsufficientWalletBalanceException ex)
        {
                Console.WriteLine(ex.Message);
        }
        
    }
}

