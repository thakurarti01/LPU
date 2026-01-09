using System;
using System.Collections.Generic;

public interface IRealEstateListing
{
    int ID {get; set;}
    string Title {get; set;}
    string Description {get; set;}
    int Price {get; set;}
    string Location {get; set;}
}

public class RealEstateListing : IRealEstateListing
{
    public int ID {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}
    public string Location {get; set;}
}

public class RealEstateApp
{
    List<IRealEstateListing> listings = new List<IRealEstateListing>()
    {
      new RealEstateListing(){ID = 101, Title = "3BHK", Description = "with all facilities", Price = 500000, Location = "Delhi"}, 
      new RealEstateListing(){ID = 131, Title = "2BHK", Description = "with gym & swimming pool", Price = 400000, Location = "Pune"}, 
      new RealEstateListing(){ID = 139, Title = "1BHK", Description = "with gym", Price = 300000, Location = "Noida"},  
    };
    

    public void AddListing(IRealEstateListing listing)
    {
        listings.Add(listing);
    }

    public void RemoveListing(int listingID)
    {
        IRealEstateListing listToRemove = null;

        foreach(IRealEstateListing item in listings)
        {
            if(item.ID == listingID)
            {
                listToRemove = item;
                break;
            }
        }

        if(listToRemove != null)
        {
            listings.Remove(listToRemove);
            Console.WriteLine("item removed!");
        }
        else
        {
            Console.WriteLine("ID not found!");
        }
        
    }

    public void UpdateListing(int listingID)
    {
        IRealEstateListing listToUpdate = null;
        
        foreach(IRealEstateListing item in listings)
        {
            if(item.ID == listingID)
            {
                listToUpdate = item;
                break;
            }
        }

        if(listToUpdate != null)
        {
            listToUpdate.Title = "duplex";
            listToUpdate.Description = "with all facilities";
            listToUpdate.Price = 550000;
            listToUpdate.Location = "Pune";
        }
        else
        {
        Console.WriteLine("ID not found!");
        }
        
    }

    public void GetListings()
    {
        foreach(IRealEstateListing name in listings)
        {
            Console.WriteLine($"{name.ID}, {name.Title}, {name.Description}, {name.Price}, {name.Location}");
        }
    }

    public void GetListingsByLocation(string location)
    {
        bool found = false;

        foreach(IRealEstateListing loc in listings)
        {
            if(loc.Location == location)
            {
                Console.WriteLine($"{loc.ID}, {loc.Title}, {loc.Description}, {loc.Price}, {loc.Location}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Location not found!");
        }  
    }

    public List<IRealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        List <IRealEstateListing> result = new List<IRealEstateListing>();
        foreach(IRealEstateListing item in listings)
        {
            if(item.Price >= minPrice && item.Price <= maxPrice)
            {
                result.Add(item);
            }
        }
        return result;
    }
}