using System;

class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message){}
}

public class GadgetValidatorUtil
{
    public bool validateGadgetID(string gadgetID)
    {
        if(gadgetID.Length == 4 && 
           char.IsUpper(gadgetID[0]) &&
           gadgetID.Substring(1).All(char.IsDigit)
        )
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
    }

    public bool validWarrantyPeriod(int period)
    {
        if(period >= 6 && period <= 36)
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
    }
}