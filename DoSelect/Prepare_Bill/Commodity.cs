using System;
using System.Collections.Generic;

enum CommodityCategory
{
    Furniture,
    Grocery,
    Service
}

class Commodity
{
    public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
    {
        
    }
}

class PrepareBill
{
    IDictionary<CommodityCategory, double> _taxRates {get;}

    public PrepareBill()
    {
        
    }

    public void SetTaxRates(CommodityCategory category, double taxRate)
    {
        
    }

    public double CalculateBillAmount(IList<Commodity> items)
    {
        
    }
}