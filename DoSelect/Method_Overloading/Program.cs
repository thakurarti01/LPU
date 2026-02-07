using System;

class Source
{
    public int Add(int a, int b, int c)
    {
        return a+b+c;
    }

    public double Add(double a, double b, double c)
    {
        return a+b+c;
    }
}

class Program
{
    static void Main()
    {
        Source obj = new Source();
        Console.WriteLine("First number");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Second number");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Third number");
        int num3 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sum of integer parameters: " + obj.Add(num1,num2,num3));

        Console.WriteLine("First number");
        double no1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Second number");
        double no2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Third number");
        double no3 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Sum of double parameters: " + obj.Add(no1,no2,no3));
    }
}