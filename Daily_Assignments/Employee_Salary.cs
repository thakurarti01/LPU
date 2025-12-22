using System;

class Employee_Salary
{
    public static void ESMain()
    {
        Console.Write("Enter Employee Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee's Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Employee's Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        string dept = "";
        string role = "";
        double basic_salary = 0;
        double final_salary = 0;
        string access_level = "";


        if(age < 21)
        {
            Console.WriteLine("Employee is not eligible to work");
        }
        else
        {
            Console.Write("Enter Department (IT/HR/FINANCE): ");
            dept = Console.ReadLine().ToUpper();
            // string role;

            switch (dept)
            {
                case "IT":
                Console.Write("Choose Role (Developer/Tester): ");
                role = Console.ReadLine().ToUpper();
                break;

                case "HR":
                Console.Write("Choose Role (Recruiter/Payroll): ");
                role = Console.ReadLine().ToUpper();
                break;

                case "FINANCE":
                Console.Write("Choose Role (Accountant/Auditor): ");
                role = Console.ReadLine().ToUpper();
                break;

                default:
                Console.Write("Invalid!");
                return;
            }

            Console.Write("Enter Basic Salary: ");
            basic_salary = Convert.ToDouble(Console.ReadLine());
            

            if(role == "DEVELOPER")
            {
                final_salary = basic_salary + (basic_salary * 30.0/100);
                Console.WriteLine("Final Salary is: " + final_salary);

                if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else if(role == "TESTER")
            {
                final_salary = basic_salary + (basic_salary * 25.0/100);
                Console.WriteLine("Final Salary is: " + final_salary);

                if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else if(role == "RECRUITER")
            {
                final_salary = basic_salary + (basic_salary * 20.0/100);
                Console.WriteLine("Final Salary is: " + final_salary);

                if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else if(role == "PAYROLL")
            {
                final_salary = basic_salary + (basic_salary * 22.0/100);
                Console.WriteLine("Final Salary is: " + final_salary);

                if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else if(role == "ACCOUNTANT")
            {
                final_salary = basic_salary + (basic_salary * 28.0/100);
                Console.WriteLine("Final Salary is: " + final_salary);

               if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else if(role == "AUDITOR")
            {
                final_salary = basic_salary + (basic_salary * 26.0 / 100);
                Console.WriteLine("Final Salary is: " + final_salary);

                if(final_salary >= 60000 && dept == "IT")
                {
                    access_level = "Admin Access";
                }
                else if(final_salary >= 60000 && dept != "IT")
                {
                    access_level = "Manager Access";
                }
                else
                {
                    access_level = "Employee Access";
                }
            }

            else
            {
                Console.WriteLine("Invalid Salary!");
            }
         }

        Console.WriteLine("\n -----Employee Details----- ");
        Console.WriteLine("Employee ID - " + id);
        Console.WriteLine("Employe Name - " + name);
        Console.WriteLine("Employe Dept - " + dept);
        Console.WriteLine("Employe Role - " + role);
        Console.WriteLine("Basic Salary - " + basic_salary);
        Console.WriteLine("Final Salary - " + final_salary);
        Console.WriteLine("Access Level - " + access_level);
    }
}