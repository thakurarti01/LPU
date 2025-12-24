// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        Cake cake = new Cake();

        Console.WriteLine(" ------- USER INPUTS HERE -------");

        Console.WriteLine("Choose Flavour: \n 1. VANILLA \n 2. CHOCOLATE \n 3. RED VELVET");
        cake.Flavour = Console.ReadLine();

        Console.Write("Enter required quantity: ");
        cake.Quantity = Convert.ToInt32(Console.ReadLine());
    
        Console.Write("Enter price per quantity: ");
        cake.PricePerKg = Convert.ToDouble(Console.ReadLine());

        try
        {
            if(cake.Flavour != "CHOCOLATE" && cake.Flavour != "RED VELVET" && cake.Flavour != "VANILLA")
            {
                throw new InvalidFlavourException("Please select available options");
            }
            Console.WriteLine("Flavour Selected!");
        }
        catch(InvalidFlavourException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("Selected Flavour: " + cake.Flavour);
        Console.WriteLine("Selected Quantity: " + cake.Quantity);
        Console.WriteLine("Price per Kg: " + cake.PricePerKg);

        cake.CakeOrder();

        // double TotalPrice = cake.CalculatePrice();
        double DiscountedPrice = cake.CalculatePrice();

        Console.WriteLine("Total Price: " + DiscountedPrice);
        // Console.Write("Discounted Price: " + CalculatePrice());
    }
}
