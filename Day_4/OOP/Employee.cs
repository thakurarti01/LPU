using System;

// =======================
// ABSTRACTION
// =======================
public abstract class Employee
{
    // =======================
    // ENCAPSULATION
    // =======================
    private int employeeId;
    private string name;

    public int EmployeeId
    {
        get { return employeeId; }
        set { employeeId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Abstract method
    public abstract double CalculateSalary();
}
