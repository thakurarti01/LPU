using System;

class Electricity
{
    public static void ElecMain()
    {
        Console.WriteLine("Enter used units: ");
        double unit = Convert.ToDouble(Console.ReadLine());

        if(unit > 0 && unit <= 199)
        {
            Console.WriteLine("Your bill is " + unit*1.20);
        }
        else if(unit > 199 && unit <= 400)
        {
            double bill = (unit-199)*1.50;
            Console.WriteLine("Your bill is " + bill);
        }
        else if(unit > 400 && unit < 600)
        {
            double bill1 = (unit-199)*0;
            //double bill2 = 
            Console.WriteLine("Your bill is " + bill1);
        }
    }
}