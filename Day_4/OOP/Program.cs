using System;

class Program
{
    static void Main()
    {
        // =======================
        // POLYMORPHISM
        // =======================
        Employee emp1 = new FullTimeEmployee();
        emp1.EmployeeId = 101;
        emp1.Name = "Arti";
        ((FullTimeEmployee)emp1).MonthlySalary = 50000;

        Employee emp2 = new PartTimeEmployee();
        emp2.EmployeeId = 102;
        emp2.Name = "Riya";
        ((PartTimeEmployee)emp2).HoursWorked = 20;
        ((PartTimeEmployee)emp2).HourlyRate = 500;

        Console.WriteLine("Employee 1 Salary: " + emp1.CalculateSalary());
        Console.WriteLine("Employee 2 Salary: " + emp2.CalculateSalary());
    }
}
