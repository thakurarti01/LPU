using System;

class Even_Odd
{
    public static void EOMain()
    {
        Console.WriteLine("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if(num % 2 == 0)
        {
            Console.WriteLine("Entered number is even");
        }
        else
        {
            Console.WriteLine("Entered number is odd");
        }
    }
}