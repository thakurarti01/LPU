using System;

class Largest_Of_Three()
{
    public static void LargestMain()
    {
        Console.WriteLine("Enter First Number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Second Number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Third Number: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        if(num1 > num2 && num1 > num3)
        {
            Console.WriteLine("Largest number is "+ num1);
        }

        else if(num2 > num1 && num2 > num3)
        {
            Console.WriteLine("Largest number is "+ num2);
        }

        else
        {
            Console.WriteLine("Largest number is " + num3);
        }
    }
}