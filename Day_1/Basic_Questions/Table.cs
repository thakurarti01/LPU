using System;

class Table
{
    public static void TableMain()
    {
        Console.Write("Enter any number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine(n + " * " + i + " = " + (n * i));
        }
    }
}