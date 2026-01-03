using System;
using System.Collections;
using System.Collections.Generic;

public class Skill
{
    public string SkillName {get; set;}
    public int Level {get; set;}

    public Skill(string skillName, int level)
    {
        SkillName = skillName;
        Level = level;
    }

    public override string ToString()
    {
        return $"Skill: {SkillName}, Level: {Level}";
    }
}

//player class behaves like a collection of skill
public class Player : IEnumerable<Skill>
{
    public string PlayerName{get; set;}

    //skill collection property
    public List <Skill> Skills {get; set;}

    public Player(string playerName)
    {
        PlayerName = playerName;
        Skills = new List <Skill>();
    }

    //add skill to player
    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }

    //IEnumerable implementation
    public IEnumerator<Skill> GetEnumerator()
    {
        return Skills.GetEnumerator();
    }

    //non generic IEnumerator implementation
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}