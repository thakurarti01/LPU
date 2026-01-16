// Q1️: Create a custom exception named NegativeNumberException.
// Task:
// -> It should inherit from Exception
// -> It should accept a custom message
// -> Write a method CheckNumber(int num)
// -> If num < 0, throw NegativeNumberException
// -> Call this method using try-catch and print the exception message

//1. CREATING CUSTOM EXCEPTION
class NegativeNumberException : Exception
{
public NegativeNumberException(string message) : base(message) 
{}
}

class Program
{
    //2. THROWING CUSTOM EXCEPTION
    static void CheckNumber(int num)
    {
        if(num < 0)
        {
            throw new NegativeNumberException("Number is negative");
        }
        Console.WriteLine("Positive Number");
    }

    //3. CATCHING CUSTOM EXCEPTION
    static void Main()
    {
        try
        {
            CheckNumber(-90);
        }
        catch(NegativeNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }   
    }
}
