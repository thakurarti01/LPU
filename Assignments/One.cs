using System;

class One
{
    public static void OneMain()
    {
        Console.WriteLine("Enter the size of array: ");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the elements of array: ");
        int[] arr = new int[N];
        for(int i = 0; i< N; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Array before sorting: ");

        for(int i = 0; i< N; i++)
        {
            Console.WriteLine(arr[i]);
        }

        // Bubble-sort
        for(int i = 0; i<N; i++)
        {
            for(int j = 0; j<N-1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    // swap(arr[j], arr[j+1]);
                    int temp = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = temp;
                }
            }
        }

        Console.WriteLine("Sorted array: ");

        for(int i = 0; i<N; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}