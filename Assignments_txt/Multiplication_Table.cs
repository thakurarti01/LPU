using System;

class Multiplication_Table
{
    public static void MTMain()
    {
        Console.WriteLine("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter a number upto you want to display table: ");
        int upto = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= upto; i++)
        {
            int mul = n*i;
            if(i == upto)
            {
                Console.Write(mul);
            }
            else
            {
                Console.Write(mul + ", ");
            }
        }

    }
}

