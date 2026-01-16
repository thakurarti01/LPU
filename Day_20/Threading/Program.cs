using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // ThreadStart - is a delegate
        ThreadStart task1 = new ThreadStart(ProcessTask1);
        ThreadStart task2 = new ThreadStart(ProcessTask2);

        Thread t1 = new Thread(task1);
        Thread t2 = new Thread(task2);

        t1.Start();
        t2.Start();

        Console.ReadLine();
    }

    static void ProcessTask1()
    {
        for(int i = 0; i<5; i++)
        {
            Console.WriteLine("Thread t1 in action");
            Thread.Sleep(5);
        }
    }

    static void ProcessTask2()
    {
        for(int i = 0; i<5; i++)
        {
            Console.WriteLine("Thread t2 in action");
            Thread.Sleep(10);
        }
    }
}