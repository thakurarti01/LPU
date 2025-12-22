using System;

class Rock_Paper_Scissor
{
    public static void RPSMain()
    {
        Console.Write("First player enter your choice: (rock/paper/scissor) ");
        string first = Console.ReadLine().ToLower();

        Console.Write("Second player enter your choice: (rock/paper/scissor) ");
        string sec = Console.ReadLine().ToLower();

        if(first == "rock")
        {
            if(sec == "paper")
            {
                Console.WriteLine("Second Player won!");
            }
            else if(sec == "scissor")
            {
                Console.WriteLine("First Player won!");
            }
            else if(sec == "rock")
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        else if(first == "paper")
        {
            if(sec == "rock")
            {
                Console.WriteLine("First Player won!");
            }
            else if(sec == "scissor")
            {
                Console.WriteLine("Second Player won!");
            }
            else if(sec == "paper")
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        else if(first == "scissor")
        {
            if(sec == "rock")
            {
                Console.WriteLine("Second Player won!");
            }
            else if(sec == "paper")
            {
                Console.WriteLine("First Player won!");
            }
            else if(sec == "scissor")
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}