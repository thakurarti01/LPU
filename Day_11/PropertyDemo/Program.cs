// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
namespace PropertyDemo
{
    struct Customer1 // value type in c#
    {
        public int ID {get; set;}
        public string Name {get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Init Customer object
            Customer custObj = new Customer();

            custObj.CustID = 101;
            custObj.Name = "Arti";
            // Init the ShippingAddr
            custObj.ShippingAddr = new Address();
            custObj.ShippingAddr.FlatNo = 1802;
            custObj.ShippingAddr.BuildingName = "Sky Tower";
            custObj.ShippingAddr.Street = "Lane 1";
            custObj.ShippingAddr.Locality = "Wakad";
            custObj.ShippingAddr.City = "Pune";

            // one customer many orders
            custObj.MyOrders = new List<Orders>()
            {
                new Orders{OrderID = 1124, OrderDate = new DateTime(2001,12,22), Amount = 14000},
                new Orders{OrderID = 2076, OrderDate = new DateTime(2002,3,12), Amount = 14000},
                new Orders{OrderID = 8540, OrderDate = new DateTime(2002,10,12), Amount = 14000},
                new Orders{OrderID = 12122, OrderDate = new DateTime(2008,1,26), Amount = 14000},
            }
        }
    }
}
