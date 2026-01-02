using System;

class Fibonacci
{
    public static void FibMain()
    {
        Console.Write("Enter any number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int first = 0;
        int sec = 1;

        for(int i = 0; i < n; i++)
        {
            if(i == 0)
            {
                Console.Write(first + " ");
                continue;
            }
            if(i == 1)
            {
                Console.Write(sec + " ");
                continue;
            }
            int next = first + sec;
            Console.Write(next + " ");
            first = sec;
            sec = next;
        }
    }
}