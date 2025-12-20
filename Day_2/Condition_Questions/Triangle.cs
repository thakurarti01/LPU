using System;

class Triangle()
{
    public static void TriangleMain()
    {
        Console.WriteLine("Enter first side: ");
        int side1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter second side: ");
        int side2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter third side: ");
        int side3 = Convert.ToInt32(Console.ReadLine());

        if((side1 == side2) && (side2 == side3))
        {
            Console.WriteLine("Equilateral Triangle");
        }
        else if(((side1 == side2) && (side2 != side3)) ||
                ((side1 == side3) && (side1 != side2)) ||
                ((side2 == side3) && (side3 != side1)))
        {
            Console.WriteLine("Isosceles Triangle");
        }
        else
        {
            Console.WriteLine("Scalene Triangle");
        }
    }
}