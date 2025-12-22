using System;

class Fibonacci_Series
{
    public static void FibMain()
    {
        Console.Write("Enter a number for series: ");
        int N = Convert.ToInt32(Console.ReadLine());

        int first = 0;
        int sec = 1;
        
        for(int i = 0; i < N; i++)
        {
            if(i == 0)
            {
                Console.WriteLine(first + " ");
                continue;
            }
            if(i == 1)
            {
                Console.WriteLine(sec + " ");
                continue;
            }
            int next = first + sec;
            Console.WriteLine(next + " ");
            first = sec;
            sec = next;
        }
    }
}