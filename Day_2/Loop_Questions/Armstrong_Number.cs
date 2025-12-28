using System;

class Armstrong_Number
{
    public static void ArmstrongMain()
    {
        int num;
        int original_number;
        int sum = 0;
        int digit;
        int n = 0; //length of num

        Console.WriteLine("Enter number to check: ");
        num = Convert.ToInt32(Console.ReadLine());

        original_number = num;
        int temp = num;
        
        while(temp != 0)
        {
            temp /= 10;
            n++;
        }

        temp = num;

        while(temp != 0)
        {
            digit = temp % 10;
            sum += (int)Math.Pow(digit, n); //type casted to int as Math.Pow always returns double value
            temp /= 10;
        }

        if(sum == original_number)
        {
            Console.WriteLine("Armstrong Number!");
        }
        else
        {
            Console.WriteLine("Not an Armstrong Number!");
        }
    }
}