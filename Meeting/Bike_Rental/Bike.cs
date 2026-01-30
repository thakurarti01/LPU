using System;
using System.Collections.Generic;

class Bike
{
    public string Model {get; set;}
    public string Brand {get; set;}
    public int PricePerDay {get; set;}
}

class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = Program.bikeDetails.Count + 1;

        Program.bikeDetails.Add(key, new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        });
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> result =
            new SortedDictionary<string, List<Bike>>();

        foreach (var item in Program.bikeDetails.Values)
        {
            if (!result.ContainsKey(item.Brand))
            {
                result[item.Brand] = new List<Bike>();
            }
            result[item.Brand].Add(item);
        }

        return result;
    }
}

