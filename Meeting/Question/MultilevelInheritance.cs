using System;

class Human
{
    public void ShowHuman()
    {
        Console.WriteLine("I am a human");
    }
}

class Adult : Human
{
    public void ShowAdult()
    {
        Console.WriteLine("I am an adult");
    }
}

class Girl : Adult
{
    public void ShowGirl()
    {
        Console.WriteLine("I am a girl");
    }
}

