using System;

class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message){}
}

class EntryUtility
{
    public bool validateEmployeeId(string employeeId)
    {
        if(employeeId.Length == 10 &&
           employeeId.StartsWith("GOAIR") &&
           employeeId[5] == '/' &&
           employeeId.Substring(6).All(char.IsDigit)
        )
        {
            return true;
        }
        else
        {
            throw new InvalidEntryException("Invalid entry details");
        }
    }

    public bool validateDuration(int duration)
    {
        if(duration >=1 && duration <= 5)
        {
            return true;
        }
        else
        {
            throw new InvalidEntryException("Invalid entry details");
        }
    }
}