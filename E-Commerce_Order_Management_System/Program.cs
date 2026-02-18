using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product(1, "Laptop", 50000, 5),
            new Product(2, "Mouse", 500, 20),
            new Product(3, "Keyboard", 1500, 8),
            new Product(4, "Monitor", 12000, 2)
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer(1, "Ravi", false),
            new Customer(2, "Amit", false),
            new Customer(3, "Neha", false)
        };

        List<Order> orders = new List<Order>();

        // Create Orders
        Order o1 = new Order(101, customers[0]);
        o1.AddItem(products[0], 1);
        o1.AddItem(products[1], 2);

        Order o2 = new Order(102, customers[1]);
        o2.AddItem(products[2], 3);

        Order o3 = new Order(103, customers[0]);
        o3.AddItem(products[3], 1);

        orders.Add(o1);
        orders.Add(o2);
        orders.Add(o3);

        // =========================
        // 🔥 LINQ OPERATIONS
        // =========================

        // 1️⃣ Orders in last 7 days
        var recentOrders = orders
            .Where(o => o.OrderDate >= DateTime.Now.AddDays(-7));

        Console.WriteLine("Recent Orders Count: " + recentOrders.Count());

        // 2️⃣ Total Revenue
        var totalRevenue = orders.Sum(o => o.GetTotalAmount());
        Console.WriteLine("Total Revenue: " + totalRevenue);

        // 3️⃣ Most Sold Product
        var mostSoldProduct = orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .OrderByDescending(g => g.Sum(i => i.Quantity))
            .FirstOrDefault();

        Console.WriteLine("Most Sold Product: " + mostSoldProduct?.Key);

        // 4️⃣ Top Customer by Spending
        var topCustomer = orders
            .GroupBy(o => o.Customer.Name)
            .Select(g => new
            {
                Customer = g.Key,
                TotalSpent = g.Sum(o => o.GetTotalAmount())
            })
            .OrderByDescending(x => x.TotalSpent)
            .FirstOrDefault();

        Console.WriteLine("Top Customer: " + topCustomer?.Customer);

        // 5️⃣ Group Orders By Status
        var groupedByStatus = orders.GroupBy(o => o.Status);

        foreach (var group in groupedByStatus)
        {
            Console.WriteLine("Status: " + group.Key + " Count: " + group.Count());
        }

        // 6️⃣ Low Stock Products (< 10)
        var lowStock = products.Where(p => p.Stock < 10);

        Console.WriteLine("Low Stock Products:");
        foreach (var p in lowStock)
        {
            Console.WriteLine(p.Name + " - Stock: " + p.Stock);
        }
    }
}
