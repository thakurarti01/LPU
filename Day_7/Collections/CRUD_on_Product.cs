using System;
using System.Collections;

class CRUD_on_Product
{
    public static void CRUDMain()
    {
        List<Product> prodList = new List<Product>()
        {
            new Product(){ID = 101, Name = "Dummy", Price = 150},
            new Product(){ID = 102, Name = "Rummy", Price = 50},
            new Product(){ID = 103, Name = "Summy", Price = 250},
            new Product(){ID = 104, Name = "Yummy", Price = 350},
        };

        // 1. CREATE - add

        Product p1 = new Product();

        Console.WriteLine("Enter ID: ");
        p1.ID = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter Name: ");
        p1.Name = Console.ReadLine();

        Console.WriteLine("Enter Price: ");
        p1.Price = Int32.Parse(Console.ReadLine());

        // passing all these values to Product
        prodList.Add(p1);

        // READ 
        Console.WriteLine("Enter ID which you want to read: ");
        int read_id = Int32.Parse(Console.ReadLine());

        Product p2 = prodList.Find(c => c.ID == read_id);

        if(p2 != null)
        {
            Console.Write($"ID: {p2.ID}\t Name: {p2.Name}\t Price: {p2.Price}");
        }

        // UPDATE 
        Console.WriteLine("Enter ID which you want to update: ");
        int update_id = Int32.Parse(Console.ReadLine());

        Product p3 = prodList.Find(c => c.ID == update_id);

        if(p3 != null)
        {
            Console.WriteLine("Enter new name: ");
            p3.Name = Console.ReadLine();

            Console.WriteLine("Enter new price: ");
            p3.Price = Int32.Parse(Console.ReadLine());
        } 

        // DELETE
        Console.WriteLine("Enter ID which you want to delete: ");
        int delete_id = Int32.Parse(Console.ReadLine());

        Product p4 = prodList.Find(c => c.ID == delete_id);

        if(p4 != null)
        {
            prodList.Remove(p4);
        }
    }
}