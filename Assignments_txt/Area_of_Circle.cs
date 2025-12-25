using System;

class Circle
{
    public static void AreaMain()
    {
        Console.WriteLine("Enter radius of circle: ");
        double rad = Convert.ToDouble(Console.ReadLine());

        double area = 2 * 3.14 * rad * rad;
        double Area = Math.Round(area, 2);

        Console.WriteLine("Area of circle is: " + Area);
    }
}