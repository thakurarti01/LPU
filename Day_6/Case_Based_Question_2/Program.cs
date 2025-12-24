// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
namespace Case_Based_Question_2;
class Program
{
    static void Main()
    {
        Console.Write("Enter Booking Id: ");
        string bookingId = Console.ReadLine() ?? "";

        CabDetails cab = new CabDetails();
        cab.bookingId = bookingId;

        if (cab.ValidateBookingId())
        {
            Console.Write("Enter Cab Type: ");
            cab.cabType = (Console.ReadLine() ?? "");

            Console.Write("Enter Distance: ");
            cab.distance = Convert.ToDouble(Console.ReadLine() ?? "0.0");

            Console.Write("Enter Waiting Time: ");
            cab.waitingTime = Convert.ToInt32(Console.ReadLine() ?? "0");

            double fare = cab.CalculateFareAmount();
            Console.WriteLine("The fare amount is " + Math.Round(fare, 2));
        }
        else
        {
            Console.WriteLine("Invalid Booking Id!");
        }
    }
}