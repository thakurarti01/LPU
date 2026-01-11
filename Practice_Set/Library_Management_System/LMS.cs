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
    private Dictionary <IBook, int> _books; //IBook contains all the property(id/title/author/category/price) and int(for quantity)

    public LibrarySystem()
    {
        _books = new Dictionary<IBook, int>();
    }

    public void AddBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            _books[book] += quantity;
        }
        else
        {
            _books.Add(book, quantity);
        }
    }

    public void RemoveBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            _books[book] -= quantity;

            if(_books[book] <= 0)
            {
                _books.Remove(book);
            }
        }
    }

    public int CalculateTotal()
    {
        int total = 0;
        foreach(var entry in _books)
        {
           IBook book = entry.Key;
           int quantity = entry.Value;
           total += book.Price * quantity; 
        }
        return total;
    }

    public List<(string title, int price)> CategoryTotalPrice()
    {
        Dictionary <(string title, int price)> tempDict = new Dictionary <(string title, int price)>();

        foreach(var entry in _books)
        {
            IBook book = entry.Key;
            int quantity = entry.Value;

            string title = book.Title;
            int price = book.Price * quantity;

            if (tempDict.ContainsKey(book))
            {
                tempDict[title] += price;
            }
            else
            {
                tempDict.Add(title, price);
            }
        }
        List <(string title, int price)> convertedList = new List <(string title, int price)>();

        foreach(var item in tempDict)
        {
            convertedList.Add((item.Key, item.Value));
        }
        return convertedList;
    }

    public List<(string title, int quantity, int price)> BooksInfo()
    {
        List<(string title, int quantity, int price)> bookList1 = new List<(string title, int quantity, int price)>();
        foreach (var entry in _books)
        {
            IBook book = entry.Key;
            int quantity = entry.Value;

            bookList1.Add((book.title, quantity, book.Price));
        } 
        return bookList1;
    }

    public List<(string category, string author, int quantity)> CategoryAndAuthorWithCount()
    {

        //created dictionary for temporary
        Dictionary<(string category, string author, int quantity)> countMap = new Dictionary<(string category, string author, int quantity)>();
        foreach(var entry in _books)
        {
            IBook book = entry.Key;
            int quantity = entry.Value;

            string category = book.Category;
            string author = book.Author;

            var key = (category, author);

            if (countMap.ContainsKey(key))
            {
                countMap[key] += quantity;
            }
            else
            {
                countMap.Add(key, quantity);
            }
        }

        //converting dict to list
        List<(string category, string author, int quantity)> result = new List<(string category, string author, int quantity)>();

        foreach (var item in countMap)
        {
            result.Add((item.Key.category, item.Key.author, item.Value));
        }
        
        return result;
    }
}