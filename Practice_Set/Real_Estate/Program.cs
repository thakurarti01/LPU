// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("======== Real Estate Listing ========");

            Console.WriteLine("1. Add: ");
            Console.WriteLine("2. Update: ");
            Console.WriteLine("3. GetListings: ");
            Console.WriteLine("4. GetListingsByLocation: ");
            Console.WriteLine("5. GetListingsByPriceRange: ");
            Console.WriteLine("6. Exit: ");

            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Title: ");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter Description: ");
                    string desc = Console.ReadLine();

                    Console.WriteLine("Enter Price: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Location: ");
                    string loc = Console.ReadLine();

                    IRealEstateListing listing = new RealEstateListing()
                    {
                        ID = id,
                        Title = title,
                        Description = desc,
                        Price = price,
                        Location = loc,
                    };

                    app.AddListing(listing);
                    break;
                }

                case 2:
                {
                   Console.WriteLine("Enter id to update"); 
                   int updateId = Convert.ToInt32(Console.ReadLine());
                   app.UpdateListing(updateId);
                   break;    
                }

                case 3:
                {
                      Console.WriteLine("All lists: ");
                      app.GetListings(); 
                      break; 
                }

                case 4:
                {
                   Console.WriteLine("Enter location to get list: ");
                   string getLoc = Console.ReadLine();
                    app.GetListingsByLocation(getLoc);   
                    break; 
                }

                case 5:
                {
                  Console.WriteLine("Enter min price: ");
                  int minPrice = Convert.ToInt32(Console.ReadLine());  

                  Console.WriteLine("Enter max price: ");
                  int maxPrice = Convert.ToInt32(Console.ReadLine());    

                  List <IRealEstateListing> newList = app.GetListingsByPriceRange(minPrice, maxPrice); 

                  if(newList.Count == 0)
                        {
                            Console.WriteLine("No lists found in this price range!");
                        }
                    else
                        {
                            foreach(var item in newList)
                            {
                                Console.WriteLine($"{item.ID},{item.Title}, {item.Description}, {item.Price}, {item.Location}");
                            }
                        }
                  break;
                }

                case 6:
                {
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;    
                }

                default:
                {
                    Console.WriteLine("Invalid choice!");    
                    break;
                }
            }   
        }
    }
}