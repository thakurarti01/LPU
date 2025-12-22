using System;

class Diamond
{
   public static void DiamMain()
    {
        Console.WriteLine("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string star = "*";

        for(int i = 1; i <= n; i++)
        {
            for(int j = i; j <= n; j++)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat(star, i)));
            }
            Console.WriteLine();
        }
            
            

        for(int i = n; i >= 1; i--)
        {
            for(int j = i; j <= n; j++)
            {
                Console.WriteLine(string.Concat(Enumerable.Repeat(star, i)));
            }
            Console.WriteLine();
        }
    } 
}

