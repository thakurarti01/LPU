using System;
using System.Collections.Generic;

public interface IBook
{
    int Id {get; set;}
    string Title {get; set;}
    string Author {get; set;}
    string Category {get; set;}
    int Price {get; set;}
}
public class Book : IBook
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}
    public string Category {get; set;}
    public int Price {get; set;}
}

public interface ILibrarySystem
{

    void AddBook(IBook book, int quantity); // adds quantity of books in the lms
    void RemoveBook(IBook book, int quantity); //removes given quantity of books from lms
    int CalculateTotal(); //returns total value of books based on their individual price and quantity
    List<(string title, int price)> CategoryTotalPrice(); //returns tuple where it will contain category name and total price of books in that category
    List<(string title, int quantity, int price)> BooksInfo(); //returns list of tuples containing title, quantity and price of book
    List<(string category, string author, int quantity)>  CategoryAndAuthorWithCount(); // returns a list of tuples containing book's category, author and quatity of books by that author in that category
}
public class LibrarySystem : ILibrarySystem
{
    private Dictionary <IBook, int> _books;
    public void AddBook(IBook book, int quantity)
    {
        
    }

    public void RemoveBook(IBook book, int quantity)
    {
        
    }

    public int CalculateTotal()
    {
        
    }

    public List<(string title, int price)> CategoryTotalPrice()
    {
        
    }

    public List<(string title, int quantity, int price)> BooksInfo()
    {
        
    }

    public List<(string category, string author, int quantity)> CategoryAndAuthorWithCount()
    {
        
    }
}