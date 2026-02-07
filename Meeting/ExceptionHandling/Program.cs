using System;

class DivideByZeroo : Exception
{
    public DivideByZeroo(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first num");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter sec num");
        int b = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (b == 0)
            {
                throw new DivideByZeroo("Divided by zero, Not possible!");
            }

            int c = a / b;
            Console.WriteLine("Result: " + c);
        }
        catch (DivideByZeroo ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
