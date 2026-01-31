using System;

class UserInterface
{
    static void Main()
    {
        EntryUtility obj = new EntryUtility();

        Console.WriteLine("Enter number of entries");
        int duration = Convert.ToInt32(Console.ReadLine());
        obj.validateDuration(duration);

        for(int i = 1; i <= duration; i++)
        {
            Console.WriteLine($"Enter entry {i} details");
            try
            {
                string employeeId = Console.ReadLine();
                obj.validateEmployeeId(employeeId);
                Console.WriteLine("Valid entry details");
                // employeeId = Console.ReadLine();
            }
            catch(InvalidEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}