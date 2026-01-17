using System;

class PasswordMismatchException : Exception
{
    public PasswordMismatchException(string message) : base(message)
    {}
}
class Program
{
    public User ValidatePassword(string name, string password, string confirmationPassword)
    {
        User userObj = new User();

        userObj.Name = name;
        userObj.Password = password;
        userObj.ConfirmationPassword = confirmationPassword;

        if(password != confirmationPassword)
        {
           throw new PasswordMismatchException("Password entered does not match"); 
        }
        Console.WriteLine("Registered Successfully");
        return userObj;
    }

    static void Main()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();
        Console.WriteLine("Enter your password again:");
        string confirmationPassword = Console.ReadLine();

        Program program = new Program();

        try
        {
            program.ValidatePassword(name, password, confirmationPassword);
        }
        catch(PasswordMismatchException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}