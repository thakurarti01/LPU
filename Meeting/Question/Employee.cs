using System;
public class Employee
{
 
    public int EmployeeID { get; set; }
    public string EmployeeName {  get; set; }
 
    public Employee()
    {
        EmployeeID = 342;
        EmployeeName = "Arti";
    }
 
    public void DisplayDetails()
    {
        Console.WriteLine($"ID: {EmployeeID}\nName: {EmployeeName}");
    }
}


 
