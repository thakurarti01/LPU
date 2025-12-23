using System;

class Ticket_Fare
{
    public static void TFMain()
    {
        
        Console.Write("Enter passenger's id: ");
        int id = Convert.ToInt32(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD

        Console.Write("Enter passenger's name: ");
        string name = (Console.ReadLine() ?? "").ToUpper(); // HANDLING TO.UPPER FUNCTION, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD

        Console.Write("Enter passenger's age: ");
        int age = Convert.ToInt32(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD

        string travel_class = "";
        double afterclass_fare = 0;
        bool gov;

        // ------ AGE ELIGIBILITY -------

        if(age < 5)
        {
            Console.WriteLine("Free Ticket - No Booking Required");
            return;
        }
        else if(age > 80)
        {
            Console.WriteLine("Medical Clearance Required");
            return;
        }
        else
        {
            Console.Write("Travel type(1-Bus/2-Train/3-Flight): ");
            int travel_type = Convert.ToInt32(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD   

            Console.Write("Base fare: ");
            double base_fare = Convert.ToDouble(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD

            Console.Write("Is government employee(true/false): ");
            bool.TryParse(Console.ReadLine() ??"false", out gov); // FOR HANDLING NULLABLE VALUE

            // ------ FARE MULTIPLIER CALCULATION ------

            switch (travel_type)
            {
                case 1:
                Console.Write("Enter travel_class(sleeper/seater): ");
                travel_class = (Console.ReadLine() ?? "").ToUpper(); // HANDLING TO.UPPER FUNCTION, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD
                break;

                case 2:
                Console.Write("Enter travel_class(general/sleeper/ac): ");
                travel_class = (Console.ReadLine() ?? "").ToUpper(); // HANDLING TO.UPPER FUNCTION, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD
                break;

                case 3:
                Console.Write("Enter travel_class(economy/business): ");
                travel_class = (Console.ReadLine() ?? "").ToUpper(); // HANDLING TO.UPPER FUNCTION, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD
                break;

                default:
                Console.WriteLine("Invalid!");
                return;
            }

            if(travel_type == 1 && travel_class == "SLEEPER")
            {
                afterclass_fare = (base_fare * 1.2);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 1 && travel_class == "SEATER")
            {
                afterclass_fare = (base_fare * 1.0);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "GENERAL")
            {
                afterclass_fare = (base_fare * 1.0);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "SLEEPER")
            {
                afterclass_fare = (base_fare * 1.3);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "AC")
            {
                afterclass_fare = (base_fare * 1.6);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 3 && travel_class == "ECONOMY")
            {
                afterclass_fare = (base_fare * 2.5);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 3 && travel_class == "BUSINESS")
            {
                afterclass_fare = (base_fare * 3.5);
                Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else
            {
                Console.WriteLine("Invalid!");
            }
        } 
    }
}