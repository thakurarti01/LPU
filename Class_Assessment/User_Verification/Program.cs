using System;

class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string message) : base(message)
    {
        
    }
}

class Program
{
    public User ValidatePhoneNumber(string name, string phoneNumber)
    {
        User obj = new User();
    
        if(phoneNumber.Length == 10)
        {
            obj.Name = name;
            obj.PhoneNumber = phoneNumber;
            return obj;
        }
        else
        {
            throw new InvalidPhoneNumberException("Invalid phone number");
        }

    }

    static void Main()
    {
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Program program = new Program();

        try
        {
            User user = program.ValidatePhoneNumber(name, phoneNumber);
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("Phone Number: " + user.PhoneNumber);
        }
        catch(InvalidPhoneNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}