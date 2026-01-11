// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Create Library System object
        ILibrarySystem library = new LibrarySystem();

        // Create some books
        IBook book1 = new Book
        {
            Id = 1,
            Title = "C# Basics",
            Author = "John Doe",
            Category = "Programming",
            Price = 500
        };

        IBook book2 = new Book
        {
            Id = 2,
            Title = "ASP.NET Core",
            Author = "John Doe",
            Category = "Programming",
            Price = 700
        };

        IBook book3 = new Book
        {
            Id = 3,
            Title = "Clean Code",
            Author = "Robert Martin",
            Category = "Software",
            Price = 800
        };

        // Add books to library
        library.AddBook(book1, 2);
        library.AddBook(book2, 1);
        library.AddBook(book3, 3);

        // Calculate total price of all books
        Console.WriteLine("Total Library Value: " + library.CalculateTotal());

        // Display books info
        Console.WriteLine("\nBooks Info:");
        var booksInfo = library.BooksInfo();
        foreach (var item in booksInfo)
        {
            Console.WriteLine($"Title: {item.title}, Quantity: {item.quantity}, Price: {item.price}");
        }

        // Display category-wise total price
        Console.WriteLine("\nCategory Total Price:");
        var categoryTotals = library.CategoryTotalPrice();
        foreach (var item in categoryTotals)
        {
            Console.WriteLine($"Category: {item.category}, Total Price: {item.price}");
        }

        // Display category & author with count
        Console.WriteLine("\nCategory & Author With Count:");
        var categoryAuthorCounts = library.CategoryAndAuthorWithCount();
        foreach (var item in categoryAuthorCounts)
        {
            Console.WriteLine(
                $"Category: {item.category}, Author: {item.author}, Quantity: {item.quantity}"
            );
        }

        // Remove some books
        library.RemoveBook(book1, 1);
        Console.WriteLine("\nAfter removing 1 copy of C# Basics:");
        Console.WriteLine("Total Library Value: " + library.CalculateTotal());
    }
}
