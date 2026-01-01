using System;

class Power
{
    public static void PowerMain()
    {
        Console.WriteLine("Enter any base number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter any number for power: ");
        int power = Convert.ToInt32(Console.ReadLine());
        

        double res = Math.Pow(num, power);

        Console.WriteLine(num + " raise to the power " + power + " is: " + res);
    }
}