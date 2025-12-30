using System;

class Greatest_of_Three
{
    public static void GOTMain()
    {
        Console.WriteLine("Enter first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter third number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        if(num1 > num2 && num1 > num3)
        {
            Console.WriteLine("First number " + num1+ " is greatest amomg all");
        }

        if(num2 > num1 && num2 > num3)
        {
            Console.WriteLine("Second number " + num2+ " is greatest amomg all");
        }

        if(num3 > num2 && num3 > num1)
        {
            Console.WriteLine("Third number " + num3+ " is greatest amomg all");
        }
        
    }
}