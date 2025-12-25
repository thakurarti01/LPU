using System;

class Largest_of_Three
{
    public static void LOTMain()
    {
        Console.WriteLine("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());

        if(a > b && a > c)
        {
            Console.WriteLine("Largest number is: " + a);
        }

        else if(b > a && b > c)
        {
            Console.WriteLine("Largest number is: " + b);
        }

        else if(c > a && c > b)
        {
            Console.WriteLine("Largest number is: " + c);
        }

        else
        {
            Console.WriteLine("Try entering different number!");
        }
    }
}