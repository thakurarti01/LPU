using System;
using System.Text;
class Program
{
    static void Main()
    {
        // Console.Write("Enter your input: ");
        // string input = Console.ReadLine();
        
        // string result = "";

        // for(int i = 0; i < input.Length; i++)
        // {
        //     result += input[i];

        //     if(i < input.Length - 1)
        //     {
        //         result += "*";
        //     }
        // }
        // Console.WriteLine("Your result: " + result);


        // -------------------- USING STRINGBUILDER -------------------------
        Console.Write("Enter your input: ");
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder(input);

        for(int i = 0; i < sb.Length; i += 2)
        {
            sb.Insert(i, "*");
        }
        Console.WriteLine("Your result: " + sb.ToString());
    }
}