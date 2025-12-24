using System;

public class LessQuantityException : Exception
{
    public LessQuantityException(string message) : base(message)
    {
        
    } 
}

public class InvalidFlavourException : Exception
{
    public InvalidFlavourException(string message) : base(message)
    {
        
    } 
}