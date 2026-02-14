using System;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("----------- Inventory Management System -----------");
        Console.WriteLine("1. Electronics");
        Console.WriteLine("2. Grocery");
        Console.WriteLine("3. Clothes");

        Console.Write("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
            Console.WriteLine("1. Mobile Phones");
            Console.WriteLine("2. Laptops");
            Console.WriteLine("3. Televisions");

            Console.Write("Enter your choice for electronic items: ");
            int elecChoice = Convert.ToInt32(Console.ReadLine());

                switch (elecChoice)
                {
                    case 1:
                    MobilePhones mob = new MobilePhones();
                    break;

                    case 2:
                    Laptops lap = new Laptops();
                    break;

                    case 3:
                    Televisions tel = new Televisions();
                    break;

                    default:
                    Console.WriteLine("Invalid choice in electronic section");
                    break;
                }
            break;

            case 2:
            Console.WriteLine("1. Rice");
            Console.WriteLine("2. Milk");
            Console.WriteLine("3. Fruits");

            Console.Write("Enter your choice for grocery items: ");
            int groChoice = Convert.ToInt32(Console.ReadLine());

                switch (groChoice)
                {
                    case 1:
                    Rice rice = new Rice();
                    break;

                    case 2:
                    Milk milk = new Milk();
                    break;

                    case 3:
                    Fruits fruit = new Fruits();
                    break;

                    default:
                    Console.WriteLine("Invalid choice in grocery section");
                    break;
                }
            break;
            
            case 3:
            Console.WriteLine("1. Shirts");
            Console.WriteLine("2. Jeans");
            Console.WriteLine("3. Jackets");

            Console.Write("Enter your choice for clothing items: ");
            int clothChoice = Convert.ToInt32(Console.ReadLine());

                switch (clothChoice)
                {
                    case 1:
                    Shirts shirt = new Shirts();
                    break;

                    case 2:
                    Jeans jeans = new Jeans();
                    break;

                    case 3:
                    Jackets jacket = new Jackets();
                    break;

                    default:
                    Console.WriteLine("Invalid choice in clothing section");
                    break;
                }
            break;

            default:
            Console.WriteLine("Invalid choice!");
            break;

        }
    }
}