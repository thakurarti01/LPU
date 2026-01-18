using System;

// =======================
// INHERITANCE
// =======================
public class FullTimeEmployee : Employee
{
    public double MonthlySalary { get; set; }

    // =======================
    // POLYMORPHISM
    // =======================
    public override double CalculateSalary()
    {
        return MonthlySalary;
    }
}
