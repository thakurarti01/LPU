using System;

public interface Room
{
    double calculateTotalBill(int nightsStayed, int joiningYear){}
    int calculateMembershipYears(int joiningYears){}
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
        int TotalBill = nightsStayed * ratePerNight;
        int MembershipYear = calculateMembershipYears(joiningYears);

        if(MembershipYear > 3)
        {
            double discount = 0.1 * TotalBill;
            double FinalBill = TotalBill - discount;
            return FinalBill;
        }
        return TotalBill;
    }
}

