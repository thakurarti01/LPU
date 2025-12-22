using System;

class Profit_Loss
{
    public static void PLMain()
    {
        Console.Write("Enter cost price: ");
        double cp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter selling price: ");
        double sp = Convert.ToDouble(Console.ReadLine());

        if (cp > sp)
        {
            double loss = Math.Round((cp-sp)/cp*100);
            Console.WriteLine("Loss Percent is: " + loss);
        }
        else if (sp > cp)
        {
            double profit = Math.Round((sp-cp)/sp*100);
            Console.WriteLine("Profit Percent is: " + profit);
        }
        else
        {
            Console.WriteLine("No profit or loss");
        }
    }
}