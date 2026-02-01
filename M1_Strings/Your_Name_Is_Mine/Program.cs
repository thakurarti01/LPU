using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the man name");
        string man = Console.ReadLine();
        
        Console.WriteLine("Enter the woman name");
        string woman = Console.ReadLine();
        
        bool isManValid = Regex.IsMatch(man, @"^[A-Za-z ]+$");
        bool isWomanValid = Regex.IsMatch(woman, @"^[A-Za-z ]+$");

        if(!isManValid && !isWomanValid)
        {
            Console.WriteLine($"Both {man} and {woman} are invalid names");
            return;
        }
        else if (!isManValid)
        {
            Console.WriteLine($"{man} is an invalid name");
            return;
        }
        else if (!isWomanValid)
        {
            Console.WriteLine($"{woman} is an invalid name");
            return;
        }
        
        if((man == woman) || (woman.Contains(man)))
        {
            Console.WriteLine($"{man} and {woman} are made for each other");
        }
        else if (man.Contains(woman))
        {
            Console.WriteLine($"{woman} and {man} are made for each other");
        }
        else
        {
            Console.WriteLine($"{woman} and {man} are not made for each other");
        }
    }
}