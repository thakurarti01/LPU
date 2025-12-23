// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    public Candy CalculateDiscountedPrice(Candy candy) //Candy -> datatype, candy -> variable(or obj)
    {
        candy.TotalPrice = candy.Quantity * candy.PricePerPiece;
        candy.Discount = 0;

        if(candy.Flavour == "STRAWBERRY")
        {
            candy.Discount = candy.TotalPrice - (candy.TotalPrice * 15/100);
        }
        else if(candy.Flavour == "LEMON")
        {
            candy.Discount = candy.TotalPrice - (candy.TotalPrice * 10/100);
        }
        else if(candy.Flavour == "MINT")
        {
            candy.Discount = candy.TotalPrice - (candy.TotalPrice * 5/100);
        }
        return candy;
    }

    public static void Main()
    {
        Candy candy = new Candy();

        Console.WriteLine(" USER INPUTS HERE ");

        Console.WriteLine("Choose your flavour: \n 1. Strawberry \n 2. Lemon \n 3. Mint");
        candy.Flavour = (Console.ReadLine() ?? "").ToUpper();

        Console.WriteLine("Enter required quantity: ");
        candy.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Price per Piece: ");
        candy.PricePerPiece = Convert.ToInt32(Console.ReadLine());

        if (candy.ValidateCandyFlavour())
        {
            Program program = new Program();
            candy = program.CalculateDiscountedPrice(candy);

            Console.WriteLine("Candy Flavour: " + candy.Flavour);
            Console.WriteLine("Candy Quanty: " + candy.Quantity);
            Console.WriteLine("Candy Price Per Piece: " + candy.PricePerPiece);
            Console.WriteLine("Candy Total Price: " + candy.TotalPrice);
            Console.WriteLine("Candy Discounted Price: " + candy.Discount);
        }
        else
        {
            Console.WriteLine("Invalid!");
            return;
        }
    }
}
