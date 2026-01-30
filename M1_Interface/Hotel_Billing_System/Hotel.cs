using System;

public interface Room
{
    double calculateTotalBill(int nightsStayed, int joiningYear);
    int calculateMembershipYears(int joiningYear)
    {
        int currentYear = DateTime.Now.Year;
        return (currentYear - joiningYear) - 1;
    }
}

public class HotelRoom : Room
{
    public string roomType;
    public double ratePerNight;
    public string guestName;

    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.guestName = guestName;
    }
    public double calculateTotalBill(int nightsStayed, int joiningYear)
    {
        double TotalBill = nightsStayed * ratePerNight;
        Room r = this;

        int MembershipYear = r.calculateMembershipYears(joiningYear);

        if(MembershipYear > 3)
        {
            double discount = 0.1 * TotalBill;
            double FinalBill = TotalBill - discount;
            return (double)(int)FinalBill;
        }
        return (double)(int)TotalBill;
    }
}

