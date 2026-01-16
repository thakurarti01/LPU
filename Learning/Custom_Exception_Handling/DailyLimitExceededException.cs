using System;

public class DailyLimitExceededException : Exception
{
    public DailyLimitExceededException(string message) : base(message)
    {
        
    }
}
