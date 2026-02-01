using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the sentence");
        string sentence = Console.ReadLine();
        if (!Regex.IsMatch(sentence, @"^[A-Za-z ]+$"))
        {
            Console.WriteLine("Invalid Sentence");
            return;
        }

        string[] word = sentence.Split(' ');
        
        int count = word.Length;
        Console.WriteLine("Word Count: " + count);

        if(count % 2 == 0)
        {
            if(word.Length >= 2)
            {
                string temp = word[0];
                word[0] = word[1];
                word[1] = temp;
            }
            Console.Write(string.Join(" ", word));
        }
        else
        {
            for(int i = 0; i < word.Length; i++)
            {
                string reversedWord = new String(word[i].Reverse().ToArray());
                Console.Write(reversedWord + " ");
            }
        }
    }
}