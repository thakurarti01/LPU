// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
namespace Case_Based_Question_1;
class Program
{

    static void Main()
    {

        Console.WriteLine("INPUTS DETAIL HERE");

        Console.WriteLine("Title: ");
        string title = Console.ReadLine();

        Console.WriteLine("Author: ");
        string author = Console.ReadLine();

        Console.WriteLine("Number of Pages: ");
        int numPages = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Due Date(dd/MM/yyyy): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Returned Date(dd/MM/yyyy): ");
        DateTime returnedDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Number of days to read: ");
        int daysToRead = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Daily late fee: ");
        double dailyLateFeeRate = Convert.ToDouble(Console.ReadLine());

        Book book = new Book(title, author, numPages, dueDate, returnedDate);

        Console.WriteLine("Enter the title: " + title);
        Console.WriteLine("Enter the author: " + author);
        Console.WriteLine("Enter the number of pages: " + numPages);
        Console.WriteLine("Enter the dueDate: " + dueDate);
        Console.WriteLine("Enter the returned date: " + returnedDate);
        Console.WriteLine("Enter the days to read: " + book.AveragePagesReadPerDay(daysToRead));
        Console.WriteLine("Enter the daily late fee: " + book.CalculateLateFee(dailyLateFeeRate));

     
    }
}