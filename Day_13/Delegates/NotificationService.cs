using System;

public class NotificationService
{
    public static void SendSMS(string message)
    {
        Console.WriteLine("SMS Notification: " + message);
    }

    public static void SendEmail(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }

    public static void SendAppAlert(string message)
    {
        Console.WriteLine("App Alert: " + message);
    }
}
