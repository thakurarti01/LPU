// Q1️: Create a custom exception named NegativeNumberException.
// Task:
// -> It should inherit from Exception
// -> It should accept a custom message
// -> Write a method CheckNumber(int num)
// -> If num < 0, throw NegativeNumberException
// -> Call this method using try-catch and print the exception message

using System;

public class NumberChecking
{
    public static void CheckNumber(int num)
    {
        if(num < 0)
        {
            throw new NegativeNumberException("Number is negative");
        }
        Console.WriteLine("Positive Number");
    }
}