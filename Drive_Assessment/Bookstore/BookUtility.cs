using System;

class BookUtility
{
    Book book = new Book();
    public void GetBookDetails()
    {
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
    }
    public void UpdateBookPrice(int newPrice)
    {
        book.Price = newPrice;
        Console.WriteLine($"Updated Price: {book.Price}");
    }
    public void UpdateBookStock(int newStock)
    {
        book.Stock = newStock;
        Console.WriteLine($"Updated Stock: {book.Stock}");
    }
}