// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main(string[] args)
    {
        // create players
        Player player = new Player("Alex");

        // add skills
        player.AddSkill(new Skill("Shooting", 8));
        player.AddSkill(new Skill("Passing", 7));
        player.AddSkill(new Skill("Dribbling", 9));
        player.AddSkill(new Skill("Defending", 6));

        // iterate over Player directly (Player behaves as a skill collection)

        Console.WriteLine($"Player: {player.PlayerName}");
        Console.WriteLine("Skills: ");

        foreach(Skill skill in player)
        {
            Console.WriteLine(skill);
        }

    }
}