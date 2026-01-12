// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();

        inventory.AddProduct(new Product { Name = "Pen", Category = "Stationery", Stock = 10, Price = 5 });
        inventory.AddProduct(new Product { Name = "Pencil", Category = "Stationery", Stock = 20, Price = 2 });
        inventory.AddProduct(new Product { Name = "Laptop", Category = "Electronics", Stock = 5, Price = 50000 });
        inventory.AddProduct(new Product { Name = "Mouse", Category = "Electronics", Stock = 15, Price = 500 });

        Console.WriteLine("Total Inventory Value: "+inventory.CalculateTotalValue());

        var stationaryProducts = inventory.GetProductsByCategory("Stationary");
        Console.WriteLine("Stationary Products: ");
        foreach(var p in stationaryProducts)
        {
            Console.WriteLine($"{p.Name} - Stock: {p.Stock} - Price: {p.Price}");
        }

        var counts = inventory.GetProductsByCategoryWithCount();
        Console.WriteLine("Products Counts by Category: ");
        foreach(var c in counts)
        {
            Console.WriteLine($"{c.category}: {c.count}");
        }

        var search = inventory.SearchProductsByName("Pen");
        Console.WriteLine("Search Results for 'Pen': ");
        foreach(var p in search)
        {
            Console.WriteLine($"{p.Name} - Category: {p.Category}");
        }

        var grouped = inventory.GetAllProductsByCategory();
        Console.WriteLine("All Products by Ctaegory: ");
        foreach(var g in grouped)
        {
            Console.WriteLine($"Category: {g.category}");
            foreach(var p in g.products)
            {
                Console.WriteLine($"{p.Name} - Stock: {p.Stock} - Price: {p.Price}");
            }
        }

        var productToRemove = search[0];
        inventory.RemoveProduct(productToRemove);
        Console.WriteLine("After removng 'Pen': ");
        Console.WriteLine("Total Inventory Value: " + inventory.CalculateTotalValue());
    }
}