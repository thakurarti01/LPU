using System;

public class Book
{
    
    public string title;
    public string author;
    public int numPages;

    DateTime dueDate;
    DateTime returnedDate;

    public Book() // default constructor
    {
    //    Console.WriteLine("Default Constructor!"); 
    }

    public Book(string t, string a, int pages, DateTime due, DateTime returned) // parameterized constructor
    {
        title = t;
        author = a;
        numPages = pages;
        dueDate = due;
        returnedDate = returned;
    }

    public double AveragePagesReadPerDay(int daysToRead)
    {
        double avg = numPages / daysToRead;
        return avg;
    }

    public double CalculateLateFee(double dailyLateFeeRate)
    {
        double NumberOfDaysLate = (returnedDate - dueDate).TotalDays; // we used .TotalDays to find the difference between days
        double fee = NumberOfDaysLate * dailyLateFeeRate;
        return fee;
    }
}