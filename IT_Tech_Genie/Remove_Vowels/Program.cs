using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your input: ");
        string input = Console.ReadLine();

        string result = "";

        foreach(char ch in input)
        {
            if("aeiouAEIOU".Contains(ch))
            {
                continue;   
            }
            result += ch;
        }

        Console.WriteLine("After removing vowels: " + result);
    }
}
