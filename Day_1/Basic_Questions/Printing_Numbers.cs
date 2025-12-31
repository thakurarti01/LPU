using System;

class Printing_Numbers
{
    public static void PNMain()
    {
        Console.WriteLine("Enter any number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}