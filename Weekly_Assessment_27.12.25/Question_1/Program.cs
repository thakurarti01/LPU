// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("============= QuickMart Traders ==============");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                SaleTransaction.CreateMethod();
                break;

                case 2:
                SaleTransaction.ViewMethod();
                break;

                case 3:
                SaleTransaction.ClearMethod();
                break;

                case 4:
                Console.WriteLine("Thank you. Application closed normally.");
                exit = true;
                break;

                default:
                Console.WriteLine("Invalid option!");
                break;

            }
        }
    }
}