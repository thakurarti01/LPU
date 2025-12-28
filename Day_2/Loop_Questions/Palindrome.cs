using System;

class Palindrome
{
    public static void PalinMain()
    {
        int num;
        int original;
        int reverse = 0;
        int digit;

        Console.WriteLine("Enter any number:");
        num = Convert.ToInt32(Console.ReadLine());

        original = num;
        while(num > 0)
        {
            digit = num % 10;
            reverse = reverse * 10 + digit;
            num = num / 10;
        }

        if(original == reverse)
        {
            Console.WriteLine("Palindrome Number!");
        }
        else
        {
            Console.WriteLine("Not a Palindrome Number!");
        }
    }
}