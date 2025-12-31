using System;

class Salary
{
    public static void SalaryMain()
    {
        Console.WriteLine("Enter employee number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter employee name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter employee basic salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        double pf = 12.0/100 * salary;
        double hra = 20.0/100 * salary;
        double da = 15.0/100 * salary;
        double gross = pf + hra + da + salary;
        double net_salary = (gross - pf);

        Console.WriteLine("Employee number: " + num);
        Console.WriteLine("Employee's name: " + name);
        Console.WriteLine("Employee's salary: " + salary);
        Console.WriteLine("Employee's gross salary: " + gross);
        Console.WriteLine("Employee's net salary: " + net_salary);
    }
}