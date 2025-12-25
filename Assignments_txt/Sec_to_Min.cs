using System;

class Sec_to_Min
{
    public static void STMain()
    {
        Console.WriteLine("Enter time in seconds: ");
        int sec = Convert.ToInt32(Console.ReadLine());

        int min = sec/60;
        double secc = sec%60;
        string formatted;

        if(secc < 10)
        {
            formatted = min + ":0" + secc;
            Console.WriteLine("formatted: " + formatted);
        }
        else
        {
            formatted = min + ":" + secc;
            Console.WriteLine("formatted: " + formatted);
        }
        
    }
}