using System;

class Leap_Year()
{
    public static void LeapMain()
    {
        Console.WriteLine("Enter any year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if((year%400 == 0) || (year%4 == 0 && year%100 != 0))
        {
            Console.WriteLine(year + " is a leap year.");
        }
        else
        {
            Console.WriteLine(year + " is not a leap year.");
        }
    }
}