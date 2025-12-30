using System;

class Result
{
    public static void ResultMain()
    {
        Console.WriteLine("Enter Roll no: ");
        int roll = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter marks of first sub: ");
        int sub1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter marks of second sub: ");
        int sub2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter marks of third sub: ");
        int sub3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter marks of fourth sub: ");
        int sub4 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter marks of fifth sub: ");
        int sub5 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter marks of sixth sub: ");
        int sub6 = Convert.ToInt32(Console.ReadLine());

        double avg = (sub1 + sub2 + sub3 + sub4 + sub5 + sub6)/6;

        if(avg >= 60.0)
        {
            Console.WriteLine(name + " - roll no " + roll + " has secured first division with average of " + avg + " marks");
        }
        else if(avg>=45.0 && avg < 60.0)
        {
            Console.WriteLine(name + " - roll no " + roll + " has secured second division with average of " + avg + " marks");
        }
        else if(avg>=30.0 && avg < 45.0)
        {
            Console.WriteLine(name + " - roll no " + roll + " has secured third division with average of " + avg + " marks");
        }
        else
        {
            Console.WriteLine(name + " - roll no " + roll + " has failed the examination");
        }
    }
}