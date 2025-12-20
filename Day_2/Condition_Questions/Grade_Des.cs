using System;

class Grade_Des()
{
    public static void GradeMain()
    {
        Console.WriteLine("Enter any grade: (E/V/G/A/F)");
        char ch = Convert.ToChar(Console.ReadLine().ToUpper());

        switch (ch)
        {
            case 'E':
            Console.WriteLine("Excellent");
            break;

            case 'V':
            Console.WriteLine("Very Good");
            break;

            case 'G':
            Console.WriteLine("Good");
            break;

            case 'A':
            Console.WriteLine("Average");
            break;

            case 'F':
            Console.WriteLine("Fail");
            break;

            default:
            Console.WriteLine("Invalid");
            break;

        }
    }
}