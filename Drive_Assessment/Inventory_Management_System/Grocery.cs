using System;

public class Grocery
{
    public DateTime ExpiryDate {get; set;}
    public int Weight {get; set;}
    public bool IsOrganic {get; set;}
    public int StorageTemperature {get; set;}
}

public class Rice : Grocery{}

public class Milk : Grocery{}

public class Fruits : Grocery{}