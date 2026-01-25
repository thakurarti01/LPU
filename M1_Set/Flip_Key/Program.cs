using System;
using System.Text;

class Program
{
    public string CleanseAndInvert(string input)
    {
        if(input == null || input.Length < 6)
        {
            return "";
        }

        input = input.ToLower();
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < input.Length; i++)
        {
            if (!char.IsLetter(input[i]))
            {
                return "";
            }

            int ascii = (int)input[i];
            if(ascii % 2 != 0)
            {
                sb.Append(input[i]);
            }
        }

        char[] reverse = sb.ToString().ToCharArray();
        Array.Reverse(reverse);

        for(int i = 0; i < reverse.Length; i++)
        {
            if(i % 2 == 0)
            {
                reverse[i] = char.ToUpper(reverse[i]);
            }
        }

        return new string(reverse);
    }

    static void Main()
    {
        Program p = new Program();

        Console.WriteLine("Enter any word: ");
        string input = Console.ReadLine();

        Console.WriteLine(p.CleanseAndInvert(input));
    }
}