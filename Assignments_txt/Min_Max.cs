using System;

class Min_Max
{
    public static void MMMain()
    {
        Console.WriteLine("Enter the size of array: ");
        int size  = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[size];
        Console.WriteLine("Enter elements of array: ");

        for(int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Provided array: ");

        for(int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + " ");
        }

        int sum = 0;
        double avg = 0;
        //double final = 0;
        int min = 0;
        int max = 0;

        for(int i = 0; i < size; i++)
        {
            min = arr.Min();
        }
        Console.WriteLine("\n min = " + min);

        for(int i = 0; i < size; i++)
        {
            max = arr.Max();
        }
        Console.WriteLine("max = " + max);

        for(int i = 0; i < size; i++)
        {
            sum+= arr[i];
            double cal = sum/size;
            avg = Math.Round(cal, 2);
        }
        Console.Write("avg = " + avg);
    }
}