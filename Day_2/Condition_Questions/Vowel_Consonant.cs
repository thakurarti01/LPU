using System;

class Vowel_Consonant()
{
    public static void VowelMain()
    {
        Console.WriteLine("Enter any character");

        char ch = Convert.ToChar(Console.ReadLine());

        switch (ch)
        {
         case 'a':
         case 'A':
         case 'e':
         case 'E':
         Console.WriteLine(ch+ " is a Vowel");  
         break; 

        //  case 'e':
        //  case 'E':
        //  Console.WriteLine(ch + " is a Vowel");  
        //  break; 

         case 'i':
         case 'I':
         Console.WriteLine(ch + " is a Vowel");  
         break; 

         case 'o':
         case 'O':
         Console.WriteLine(ch + " is a Vowel");  
         break; 

         case 'u':
         case 'U':
         Console.WriteLine(ch + " is a Vowel");  
         break; 

        default:
        Console.WriteLine(ch + " is a Consonant");
        break;
        }

    }
}