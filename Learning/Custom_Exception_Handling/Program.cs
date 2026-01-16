using System;

class Program
{
     static void Main()
    {
        // NUMBER CHECKING EXCEPTION CATCHING
        // try
        // {
        //     NumberChecking.CheckNumber(-90);
        // }
        // catch(NegativeNumberException ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }  

        // LIMIT EXCEEDING EXCEPTION CATCHING
        
        try
        {
            BankService.Withdraw(15000);
        }
        catch(DailyLimitExceededException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        } 
    }
}
