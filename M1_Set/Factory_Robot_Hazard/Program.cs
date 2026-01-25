using System;

class Program
{
    static void Main()
    {
        RoboHazardAuditor obj = new RoboHazardAuditor();

       
        Console.WriteLine("Enter Arm Precision(0.0 - 1.0): ");
        double armPrecision = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Worker Density(1 - 20): ");
        int workerDensity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Machinery State(Worn/Faulty/Critical): ");
        string machineryState = Console.ReadLine();
        
        try
        {
            double result = obj.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
            Console.WriteLine("Robot Hazard Risk Score: " + result);
        }
        catch(RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}