using System;

class Calculator()
{
    public static void CalMain()
    {
        Console.WriteLine("Enter First Operand");
        int first = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Second Operand");
        int sec = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter any operator (+,-,*,/)");
        char ch = Console.ReadLine()![0];

        switch (ch)
        {
            case '+':
            Console.WriteLine(first+sec);
            break;

            case '-':
            Console.WriteLine(first-sec);
            break;

            case '*':
            Console.WriteLine(first*sec);
            break;

            case '/':
            Console.WriteLine(first/sec);
            break;

            default:
            Console.WriteLine("Invalid Operator");
            break;
        }

    }
}