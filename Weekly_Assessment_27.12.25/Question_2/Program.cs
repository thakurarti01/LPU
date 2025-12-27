// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        bool exit = false;
        while (!exit)
            {
                Console.WriteLine("\n========== MediSure Clinic Billing ==========");
                Console.WriteLine("1. Create New Bill");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        PatientBill.CreateMethod();
                        break;

                    case 2:
                        PatientBill.ViewMethod();
                        break;

                    case 3:
                        PatientBill.ClearMethod();
                        break;

                    case 4:
                        Console.WriteLine("Application closed.");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
    }
}
        
