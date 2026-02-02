using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the username");
        string user = Console.ReadLine();

        bool validUsername = user.Length == 8 && 
                             Regex.IsMatch(user.Substring(0, 4), @"^[A-Z]{4}$")&&
                             user[4] == '@' &&
                             int.TryParse(user.Substring(5, 3), out int num) && (num>=101 && num<=115);

        if (!validUsername)
        {
            Console.WriteLine(user + " is an invalid username");
            return;
        }

        string lower = user.Substring(0, 4).ToLower();
        int sum = 0;

        for(int i = 0; i < lower.Length; i++)
        {
            sum = sum + (int)lower[i];
        }

        string last = user.Substring(6, 2);
        string password = "TECH_" + sum.ToString() + last;

        Console.WriteLine("Password: " + password);

    }
}