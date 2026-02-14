using System;

class Program
{
    static void Main()
    {
        BookUtility utility = new BookUtility();
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("1. Get Details");
            Console.WriteLine("2. Update Price");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. Exit");

            Console.Write("Enter Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var book = utility.GetBook();
                    Console.WriteLine($"ID: {book.Id}, Author: {book.Author}, Price: {book.Price}, Stock: {book.Stock}");
                    break;

                case 2:
                    Console.Write("Enter New Price: ");
                    int price = Convert.ToInt32(Console.ReadLine());
                    utility.UpdatePrice(price);
                    break;

                case 3:
                    Console.Write("Enter New Stock: ");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    utility.UpdateStock(stock);
                    break;

                case 4:
                    Console.WriteLine("Thank You");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
