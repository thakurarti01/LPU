using System;
using System.Collections.Generic;

public class Employee : IComparable<Employee>
{
    public int Id {get; set;}
    public string Name {get; set;}
    public decimal Salary {get; set;}

    public Employee (int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    // default sorting logic by salary
    public int CompareTo(Employee other)
    {
        if(other == null)
        {
            return 1;
        }
        return this.Salary.CompareTo(other.Salary);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}: {Name}, Salary: {Salary}";
    }
}