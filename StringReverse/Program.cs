using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "ArtiThakur";
        char[] rev = str.ToString().ToCharArray();
        Array.Reverse(rev);
        Console.WriteLine("reverse: " + new String(rev));

        for(int i = 0; i <rev.Length; i++)
        {
            if(Regex.IsMatch(rev, @"^[AEIOUaeiou]"))
            {
                
            }
        }
    }
}