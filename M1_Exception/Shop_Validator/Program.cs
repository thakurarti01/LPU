using System;

class UserInterface
{
    static void Main()
    {
        Console.WriteLine("Enter the number of gadget entries");
        int entry = Convert.ToInt32(Console.ReadLine());

        GadgetValidatorUtil obj = new GadgetValidatorUtil();

        for(int i = 1; i <= entry; i++)
        {
            Console.WriteLine($"Enter gadget {i} details");
            string[] details = Console.ReadLine().Split(':');

            try
            {
                string gadgetID = details[0];
                int period = Convert.ToInt32(details[2]);

                obj.validateGadgetID(gadgetID);
                obj.validWarrantyPeriod(period);

                Console.WriteLine("Warranty accepted, stock updated");
            }
            catch(InvalidGadgetException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}