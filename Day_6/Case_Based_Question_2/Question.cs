using System;

public class Cab
{
    public string bookingId{get; set;}
    public string cabType{get; set;}
    public double distance{get; set;}
    public int waitingTime{get; set;}
}

public class CabDetails : Cab
{
    public bool ValidateBookingId()
    {
        bool cond1 = bookingId.Length == 6;

        string[] parts = bookingId.Split('@');

        if(parts.Length == 2)
        {
            string beforeAt = parts[0];
            string afterAt = parts[1];

            bool cond2 = beforeAt.Contains("AC");

            bool cond3 = afterAt.Length == 3 &&
                         char.IsDigit(afterAt[0]) &&
                         char.IsDigit(afterAt[1]) &&
                         char.IsDigit(afterAt[2]);

            if(cond1 && cond2 && cond3)
            {
                return true;
            }
        }
        return false;
    }

    public double CalculateFareAmount()
    {
        double waitingCharge = Math.Sqrt(waitingTime);
        double fare = 0;

        if(cabType.ToUpper() == "HATCHBACK")
        {
           fare = distance * 10 + waitingCharge; 
        }

        else if(cabType.ToUpper() == "SEDAN")
        {
           fare = distance * 20 + waitingCharge; 
        }

        else if(cabType.ToUpper() == "SUV")
        {
           fare = distance * 30 + waitingCharge; 
        }

        return fare;
    }
}
