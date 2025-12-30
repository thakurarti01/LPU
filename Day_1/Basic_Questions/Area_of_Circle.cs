using System;

class Area_of_Circle
{
    public static void AreaMain()
    {
        Console.WriteLine("Enter radius of circle: ");
        int rad = Convert.ToInt32(Console.ReadLine());

        double area = 2*3.14*rad*rad;

        Console.WriteLine("Area of circle: " + area);
    }
}