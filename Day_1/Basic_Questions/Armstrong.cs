using System;

class Armstrong
{
    public static void ArmMain()
    {
        int num, original, sum = 0, digit, n = 0;

        Console.WriteLine("Enter any number: ");
        num = Convert.ToInt32(Console.ReadLine());

        original = num;

        int temp = num;

        while(temp != 0)
        {
            temp /= 10;
            n++; // length of no
        }

        temp = num;

        while(temp != 0)
        {
            digit = temp % 10; // no of digits of n
            sum += (int)Math.Pow(digit, n);
            temp /= 10;
        }

        if(sum == original)
        {
            Console.WriteLine("Armstrong!");
        }
        else
        {
            Console.WriteLine("Not an Armstrong!");
        }
    }
}