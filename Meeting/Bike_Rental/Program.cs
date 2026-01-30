using System;
using System.Collections.Generic;

class Program
{
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
    static void Main()
    {
        BikeUtility utility = new BikeUtility();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1.Add Bike Details: ");
            Console.WriteLine("2. Group Bikes By Brand: ");
            Console.WriteLine("Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the model");
                        string Model = Console.ReadLine();
                        Console.WriteLine("Enter the brand");
                        string Brand = Console.ReadLine();
                        Console.WriteLine("Enter the price per day");
                        int PricePerDay = Convert.ToInt32(Console.ReadLine());
                        utility.AddBikeDetails(Model, Brand, PricePerDay);
                        Console.WriteLine("Bike details added successfully");
                        break;
                    }
                case 2:
                    {
                        var items = utility.GroupBikesByBrand();
                        foreach(var item in items)
                        {
                            Console.WriteLine(item.Key);
                            foreach (var bike in item.Value)
                            {
                                Console.WriteLine(bike.Model);
                            }

                        } 
                        break;
                    }

                case 3:
                    {
                        exit = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice!");
                        break;
                    }
            }
        }
    }

}

