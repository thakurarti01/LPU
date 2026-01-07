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
      new RealEstateListing(){ID = 101, Title = "2BHK", Description = "with gym & swimming pool", Price = 400000, Location = "Pune"}, 
      new RealEstateListing(){ID = 101, Title = "1BHK", Description = "with gym", Price = 300000, Location = "Noida"},  
    };
    

    public void AddListing(IRealEstateListing listings)
    {
        listings.Add(IRealEstateListing);
    }

    public void RemoveListing(int listingID)
    {
        IRealEstateListing listToRemove = null;

        foreach(IRealEstateListing id in listings)
        {
            if(id.ID == listingID)
            {
                listToRemove = listingID;
                break;
            }

            if(listToRemove != null)
            {
                listings.Remove(listToRemove);
                Console.WriteLine("ID removed!");
            }
            else
            {
                Console.WriteLine("ID not found!");
            }
        }
    }

    public void UpdateListing(IRealEstateListing listing)
    {
        IRealEstateListing idToUpdate = null;
        
        foreach(IRealEstateListing id in listingID)
        {
            if(id.ID == listingID)
            {
                idToUpdate = id;
                break;
            }

            if(idToUpdate != null)
            {
                Title = "duplex";
                Description = "with all facilities";
                Price = 550000;
                Location = "Pune";
            }
            else
            {
            Console.WriteLine("ID not found!");
            }
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
        IRealEstateListing listToFind = null;

        foreach(IRealEstateListing loc in listings)
        {
            if(loc.Location == location)
            {
                listToFind = loc;
                break;
            }

            if(listToFind != null)
            {
                foreach(IRealEstateListing name in listings)
                {
                    Console.WriteLine($"{name.ID}, {name.Title}, {name.Description}, {name.Price}, {name.Location}");
                }
            }
            else
            {
                Console.WriteLine("Location not found!");
            }
        }
    }
}