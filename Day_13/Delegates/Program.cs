using System;

class Program
{
    static void Main()
    {
        Bank bank = new Bank(5000);

        // ==============================
        // SINGLE-CAST DELEGATE
        // ==============================
        bank.OnTransaction = NotificationService.SendSMS;

        bank.Deposit(1000);

        // ==============================
        // MULTI-CAST DELEGATE
        // ==============================
        bank.OnTransaction += NotificationService.SendEmail;
        bank.OnTransaction += NotificationService.SendAppAlert;

        bank.Withdraw(2000);

        // ==============================
        // DELEGATE AS METHOD PARAMETER
        // ==============================
        ProcessTransaction(
            3000,
            bank.Withdraw
        );

        // ==============================
        // BUILT-IN DELEGATES
        // ==============================

        // Func delegate
        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine("Func Result: " + add(10, 20));

        // Action delegate
        Action<string> print = msg => Console.WriteLine("Action: " + msg);
        print("Transaction Successful");

        // Predicate delegate
        Predicate<int> isPositive = x => x > 0;
        Console.WriteLine("Predicate Result: " + isPositive(10));
    }

    static void ProcessTransaction(double amount, Action<double> transaction)
    {
        transaction(amount);
    }
}
