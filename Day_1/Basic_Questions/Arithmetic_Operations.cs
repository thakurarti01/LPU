using System;

class Arithmetic_Operations
{
    public static void OperationMain()
    {
        Console.WriteLine("Enter a number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter another number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose any one operator(+,-,*,/): ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
            Console.WriteLine("Result: " + (num1+num2));
            break;

            case "-":
            Console.WriteLine("Result: " + (num1-num2));
            break;

            case "*":
            Console.WriteLine("Result: " + (num1*num2));
            break;

            case "/":
            Console.WriteLine("Result: " + (num1/num2));
            break;

            default:
            Console.WriteLine("Invalid operator!");
            break;
        }
    }
}