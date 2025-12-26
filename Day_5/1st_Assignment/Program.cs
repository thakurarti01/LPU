// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("USER INPUTS HERE");

        Console.WriteLine("Choose: \n LAPTOP \nDESKTOP");
        string device = Console.ReadLine().ToUpper();

        if(device == "DESKTOP")
        {
            Desktop desk = new Desktop();

            Console.WriteLine("Processor: ");
            desk.Processor = Console.ReadLine();

            Console.WriteLine("Enter RamSize(gb): ");
            desk.RamSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter HardDiskSize(tb): ");
            desk.HardDiskSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter GraphicCard(gb): ");
            desk.GraphicCard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter MonitorSize: ");
            desk.MonitorSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter PowerSupply: ");
            desk.PowerSupply = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Price of your " + device + " is: " + desk.DesktopPriceCalculation()); //here we called the method
        }

        else if(device == "LAPTOP")
        {
            Laptop lap = new Laptop();

            Console.WriteLine("Processor: ");
            lap.Processor = Console.ReadLine();

            Console.WriteLine("Enter RamSize(gb): ");
            lap.RamSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter HardDiskSize(tb): ");
            lap.HardDiskSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter GraphicCard(gb): ");
            lap.GraphicCard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter DisplaySize: ");
            lap.DisplaySize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Battery: ");
            lap.Battery = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Price of your " + device + " is: " + lap.LaptopPriceCalculation());

        }

        else
        {
            Console.WriteLine("Invalid!");
        }

    }
}