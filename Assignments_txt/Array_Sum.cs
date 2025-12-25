using System;

class Array_Sum
{
    public static void ASMain()
    {
        Console.WriteLine("Enter size of an array: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[size];
        Console.WriteLine("Enter elements of array: ");

        for(int i = 0; i < size; i++)
        {
           arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Provided array is: ");

        for(int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + " ");
        }

        int sum = 0;
        for(int i = 0; i < size; i++)
        {
            // sum += arr[i];
            if(arr[i] == 0)
            {
                break;
            }

            else if(arr[i] < 0)
            {
                continue;
            }

            else
            {
                sum += arr[i];   
            }
        }
        Console.WriteLine("\nSum: " + sum);

    }
}