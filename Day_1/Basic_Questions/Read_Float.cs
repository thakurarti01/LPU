using System;

class Read_Float
{
    public static void ReadMain()
    {
        Console.WriteLine("Enter a floating number: ");
        double n = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("You entered: " + n);
    }
}