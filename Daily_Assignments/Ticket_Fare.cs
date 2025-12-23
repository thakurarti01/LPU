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
        int travel_type;
        double base_fare = 0;
        double afterclass_fare = 0;
        bool gov;
        double discount = 0;
        double final_fare = 0;
        string booking_status = "";

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
            travel_type = Convert.ToInt32(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD   

            Console.Write("Base fare: ");
            base_fare = Convert.ToDouble(Console.ReadLine() ?? "0"); // HANDLING NULLABLE VALUE, IF USER DOES NOT PROVIDE INFO, THIS WILL NOT CAUSE ANY ERROR, 0 WILL BE ASSIGNED TO THIS FIELD

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
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 1 && travel_class == "SEATER")
            {
                afterclass_fare = (base_fare * 1.0);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "GENERAL")
            {
                afterclass_fare = (base_fare * 1.0);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "SLEEPER")
            {
                afterclass_fare = (base_fare * 1.3);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 2 && travel_class == "AC")
            {
                afterclass_fare = (base_fare * 1.6);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 3 && travel_class == "ECONOMY")
            {
                afterclass_fare = (base_fare * 2.5);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else if(travel_type == 3 && travel_class == "BUSINESS")
            {
                afterclass_fare = (base_fare * 3.5);
                // Console.WriteLine("Your total after class fare is: " + afterclass_fare);
            }

            else
            {
                Console.WriteLine("Invalid!");
                return;
            }

            Console.WriteLine("Your total after class fare is: " + afterclass_fare);

            // ------- DISCOUNT CALCULATION -------
            if(age >= 60)
            {
                discount = 0.3 * afterclass_fare;
            }
            
            else if(gov)
            {
                discount = 0.15 * afterclass_fare;
            }
            else if(age >= 5 && age <= 12)
            {
                discount = 0.5 * afterclass_fare;
            }
            else
            {
                discount = 0;
            }

            final_fare = afterclass_fare-discount;
            Console.WriteLine("Your FINAL FARE is: " + final_fare);

            // -------- BOOKING STATUS -------
            
            if(final_fare >= 10000)
            {
                if(travel_type == 3)
                {
                    booking_status = "Confirmed!";
                }
                else
                {
                    booking_status = "Waiting List";
                }
            }
            else
            {
                booking_status = "Confirmed!";
            }
        } 

        // ------- DISPLAYING TICKET SUMMARY --------

        Console.WriteLine("---------- YOUR TICKET SUMMARY --------");
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Travel Type: " + travel_type);
        Console.WriteLine("Class: " + travel_class);
        Console.WriteLine("Base Fare: " + base_fare);
        Console.WriteLine("After Class Fare: " + afterclass_fare);
        Console.WriteLine("Discount: " + discount);
        Console.WriteLine("Final Fare: " + final_fare);
        // Console.WriteLine("Discount: " + discount);
        Console.WriteLine("Booking Status: " + booking_status);
    }
}