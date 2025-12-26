using System;

public class Computer
{
    public string Processor{get; set;}
    public int RamSize{get; set;}
    public int HardDiskSize{get; set;}
    public int GraphicCard{get; set;}
}

public class Desktop : Computer
{
    public int MonitorSize{get; set;} 
    public int PowerSupply{get; set;}  

    double total; 

    public double DesktopPriceCalculation()
    {
        switch (Processor)
        {
            case "i3":
            {
                total = 1500 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (MonitorSize * 250) + (PowerSupply * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            case "i5":
            {
                total = 3000 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (MonitorSize * 250) + (PowerSupply * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            case "i7":
            {
                total = 4500 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (MonitorSize * 250) + (PowerSupply * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            // default:
            // {
            //      Console.WriteLine("Invalid!");   
            // }
        }
        return total;
    }
}

public class Laptop : Computer
{
    public int DisplaySize{get; set;}
    public int Battery{get; set;}

    double total;

    public double LaptopPriceCalculation() 
    {
        switch (Processor)
        {
            case "i3":
            {
                total = 2500 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (DisplaySize * 250) + (Battery * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            case "i5":
            {
                total = 5000 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (DisplaySize * 250) + (Battery * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            case "i7":
            {
                total = 6500 + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (DisplaySize * 250) + (Battery * 20);
                // Console.WriteLine("Desktop price is: " + total); 
                return total;
            }
            // default:
            // Console.WriteLine("Invalid!");   
            
        }
        return total;
    }
}