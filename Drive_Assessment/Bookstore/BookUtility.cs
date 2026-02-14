using System;

public class BookUtility
{
    private Book book;

    public BookUtility()
    {
        string data = "BK01 JavaBook 750 20";
        string[] arr = data.Split(' ');

        book = new Book
        {
            Id = arr[0],
            Author = arr[1],
            Price = Convert.ToInt32(arr[2]),
            Stock = Convert.ToInt32(arr[3])
        };
    }

    public Book GetBook()
    {
        return book;
    }

    public void UpdatePrice(int newPrice)
    {
        book.Price = newPrice;
        Console.WriteLine("Price Updated Successfully");
    }

    public void UpdateStock(int newStock)
    {
        book.Stock = newStock;
        Console.WriteLine("Stock Updated Successfully");
    }
}
