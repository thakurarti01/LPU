using System;

class Sum_of_Numbers
{
    public static void SONMain()
    {
        Console.WriteLine("Enter any number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int i = num;
        while(i > 0)
        {
            sum += i;
            i--;
        }
        Console.WriteLine("Sum is: " + sum);
    }
}