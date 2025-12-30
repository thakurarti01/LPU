using System;

class Read_Number
{
    public static void ReadMain()
    {
        Console.WriteLine("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("You entered: " + n);
    }
}