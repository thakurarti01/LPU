using System;

class Greatest_of_Two
{
    public static void GOTMain()
    {
        Console.WriteLine("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if(num1 > num2)
        {
            Console.WriteLine("The first number " + num1 + " is greatest among two");
        }
        else
        {
            Console.WriteLine("The second number " + num2 + " is greatest among two");
        }

    }
}