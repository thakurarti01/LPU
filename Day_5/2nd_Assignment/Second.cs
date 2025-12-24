using System;

public class Cake
{
    public string Flavour{get; set;}
    public int Quantity{get; set;}
    public double PricePerKg{get; set;}

    double TotalPrice = 0;
    double DiscountedPrice = 0;

    public bool CakeOrder()
    {
        if(Flavour == "CHOCOLATE" || Flavour == "RED VELVET" || Flavour == "VANILLA")
        {
            return true;
        }
        else
        {
            throw new InvalidFlavourException("Flavour not available. Please select the available flavour");
        }

        if (Quantity > 0)
        {
            return true;
        }
        throw new LessQuantityException("Quantity must be greater than 0");
    }

    

    public double CalculatePrice()
    {
        if (Flavour == "VANILLA")
        {
            TotalPrice = Quantity * PricePerKg;
            DiscountedPrice = TotalPrice - (TotalPrice * 3.0/100);
        }

        else if (Flavour == "CHOCOLATE")
        {
            TotalPrice = Quantity * PricePerKg;
            DiscountedPrice = TotalPrice - (TotalPrice * 5.0/100);
        }

        else if (Flavour == "RED VELVET")
        {
            TotalPrice = Quantity * PricePerKg;
            DiscountedPrice = TotalPrice - (TotalPrice * 10.0/100);
        }

        return DiscountedPrice;
    }
}