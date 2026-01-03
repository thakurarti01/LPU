// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main(string[] args)
    {
        List <Employee> employees = new List<Employee>
        {
            new Employee(101, "Alice", 50000),
            new Employee(102, "Bob", 75000),
            new Employee(103, "Charlie", 60000),
            new Employee(104, "David", 45000),
        };

        Console.WriteLine("Before sorting");
        PrintEmployees(employees);

        employees.Sort();

        Console.WriteLine("After sorting"); 
        PrintEmployees(employees);
    }

    static void PrintEmployees(List <Employee> employees)
    {
        foreach(var emp in employees)
        {
            Console.WriteLine(emp);
        }
    }
}
