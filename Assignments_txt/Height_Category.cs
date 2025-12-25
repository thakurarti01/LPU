using System;

class Height_Category
{
    public static void HCMain()
    {
        Console.WriteLine("Enter height in cm: ");
        int height = Convert.ToInt32(Console.ReadLine());

        if(height < 0)
        {
            Console.WriteLine("Invalid!");
        }
        else if(height > 0 && height < 150)
        {
            Console.WriteLine("Short");
        }
        else if(height >= 150 && height < 180)
        {
            Console.WriteLine("Average");
        }
        else
        {
            Console.WriteLine("Tall");
        }
    }
}