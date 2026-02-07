using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first word");
        string word1 = Console.ReadLine();
        Console.WriteLine("Enter second word");
        string word2 = Console.ReadLine();

        int deletions = 0;

        foreach (char c in word1)
        {
            if (!word2.Contains(c))
                deletions++;
        }

        Console.WriteLine(deletions);
    }
}
