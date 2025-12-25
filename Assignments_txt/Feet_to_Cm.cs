using System;

class Conversion
{
    public static void ConvertMain()
    {
        Console.WriteLine("Enter feet: ");
        int feet = Convert.ToInt32(Console.ReadLine());

        double cm = Math.Round((feet * 30.48), 2);
        Console.WriteLine(feet + " is equal to " + cm + " cm");
    }
}