using System;

class Even_Numbers
{
    public static void ENMain()
    {
        Console.WriteLine("Enter any number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for(int i = 1; i <= n; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            else
            {
                continue;
            }
        }
    }
}