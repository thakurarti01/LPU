using System;

class UserInterface
{
    static void Main()
    {
        //deluxe room
        Console.WriteLine("Enter Deluxe Room Details:");

        Console.Write("Guest Name: ");
        string deluxeName = Console.ReadLine();
        
        Console.Write("Rate per Night: ");
        int deluxeRate = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Nights Stayed: ");
        int deluxeNight = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Joining Year: ");
        int deluxeJoining = Convert.ToInt32(Console.ReadLine());

        HotelRoom obj1 = new HotelRoom("Deluxe", deluxeRate, deluxeName);
        Room r1 = obj1;

        int deluxeMembership = r1.calculateMembershipYears(deluxeJoining);
        double deluxeBill = obj1.calculateTotalBill(deluxeNight, deluxeJoining);


        //suite room
        Console.WriteLine("Enter Suite Room Details:");

        Console.Write("Guest Name: ");
        string suiteName = Console.ReadLine();

        Console.Write("Rate per Night: ");
        int suiteRate = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nights Stayed: ");
        int suiteNight = Convert.ToInt32(Console.ReadLine());

        Console.Write("Joining Year: ");
        int suiteJoining = Convert.ToInt32(Console.ReadLine());

        HotelRoom obj2 = new HotelRoom("Suite", suiteRate, suiteName);
        Room r2 = obj2;

        int suiteMembership = r2.calculateMembershipYears(suiteJoining);
        double suiteBill = obj2.calculateTotalBill(suiteNight, suiteJoining);

        Console.WriteLine("Room Summary:");
        Console.WriteLine($"Deluxe Room: {obj1.guestName}, {obj1.ratePerNight.ToString("F1")} per night, Membership: {deluxeMembership} years");
        Console.WriteLine($"Suite Room: {obj2.guestName}, {obj2.ratePerNight.ToString("F1")} per night, Membership: {suiteMembership} years");

        Console.WriteLine("Total Bill: ");
        Console.WriteLine($"For {obj1.guestName} (Deluxe) : {deluxeBill.ToString("F1")}");
        Console.WriteLine($"For {obj2.guestName} (Suite) : {suiteBill.ToString("F1")}");
    }
}