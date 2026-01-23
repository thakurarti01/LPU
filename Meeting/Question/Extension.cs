using System;

public static class ExtensionMethods
{
    public static string EvenOrOdd(this int num)
    {
        if(num % 2 == 0)
        {
            return "Even";
        }
        else
        {
            return "Odd";
        }
    }
}

