using System;
using System.Collections.Generic;

class Person
{
    public string Name {get; set;}
    public string Address {get; set;}
    public int Age {get; set;}
}

class PersonImplementation
{
    public string GetName(IList<Person> person)
    {
        string result = "";
        foreach(Person p  in person)
        {
            result += p.Name + " " + p.Address + " ";
        }
        return result;
    }

    public double Average(IList<Person> person)
    {
        // return person.Average(p => p.Age); -- in LINQ

        int sum = 0;
        foreach(Person p in person)
        {
            sum += p.Age;
        }
        return (double)sum/person.Count;
    }

    public int Max(IList<Person> person)
    {
        int maxAge = person[0].Age;
        foreach(Person p in person)
        {
            if(p.Age > maxAge)
            {
                maxAge = p.Age;
            } 
        }
        return maxAge;
    }
}
