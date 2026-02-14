using System;

public class Electronics
{
    public string Brand {get; set;}
    public string Model {get; set;}
    public int WarrantyPeriod {get; set;}
    public int PowerUsage {get; set;}
    public DateTime ManufacturingDate {get; set;}
}

public class MobilePhones : Electronics
{
    
}

public class Laptops : Electronics
{
    public int RAM {get; set;}
    public int Storage {get; set;}
}

public class Televisions : Electronics
{
    
}