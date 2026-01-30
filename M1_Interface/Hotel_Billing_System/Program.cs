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

        HotelRoom obj1 = new HotelRoom("Deluxe", deluxeNight, deluxeName);

        int deluxeMembership = deluxe.calculateMembershipYears(deluxeJoining);
        double deluxeBill = deluxe.calculateTotalBill(deluxeNight, deluxeJoining);


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

        int suiteMembership = suite.calculateMembershipYears(suiteJoining);
        double suiteBill = suite.calculateTotalBill(suiteNight, suiteJoining);

    }
}