using System;

class Pos_Neg_Zero
{
    public static void PNZMain()
    {
        Console.WriteLine("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if(num > 0)
        {
            Console.WriteLine("Positive number");
        }
        else if(num < 0)
        {
            Console.WriteLine("Negative number");
        }
        else
        {
            Console.WriteLine("Zero");
        }
    }
}