// Q3️⃣: You are building a banking application.
// Task:
// -> Create a custom exception DailyLimitExceededException
// -> Daily withdrawal limit = 10000
// -> Write a method Withdraw(int amount)
// -> If amount > 10000, throw the custom exception
// -> Otherwise print "Withdrawal successful"
// -> Handle the exception properly in Main()
// -> Also include a general exception catch, but follow best practice order

using System;

public class BankService
{
    public static void Withdraw(int amount)
    {
        if(amount > 10000)
        {
            throw new DailyLimitExceededException("Limit exceeded");
        }
        Console.WriteLine("Withdrawl successful");
    }
}

