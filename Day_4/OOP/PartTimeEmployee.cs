using System;

// =======================
// INHERITANCE
// =======================
public class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }
    public double HourlyRate { get; set; }

    // =======================
    // POLYMORPHISM
    // =======================
    public override double CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}
