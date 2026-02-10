using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    switch (choice)
                    {
                        case "1":
                        Console.Write("Course Code: ");
                        string code = Console.ReadLine();

                        Console.Write("Course Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Credits: ");
                        int credits = int.Parse(Console.ReadLine());

                        system.AddCourse(code, name, credits);
                        Console.WriteLine("course added successfully");
                        break;

                        case "2":
                        Console.Write("Student Id: ");
                        string id = Console.ReadLine();

                        Console.Write("Student Name: ");
                        string studentName = Console.ReadLine();

                        Console.Write("Major: ");
                        string major = Console.ReadLine();

                        system.AddStudent(id, studentName, major);
                        Console.WriteLine("student added successfully");
                        break;

                        case "3":
                        Console.Write("Student ID: ");
                        string regId = Console.ReadLine();

                        Console.Write("Course Code: ");
                        string regCourse = Console.ReadLine();

                        if (system.RegisterStudentForCourse(regId, regCourse))
                            Console.WriteLine("Course registered successfully.");
                        else
                            Console.WriteLine("Registration failed.");
                        break;

                        case "4":
                        Console.Write("Student ID: ");
                        string dropId = Console.ReadLine();

                        Console.Write("Course Code: ");
                        string dropCourse = Console.ReadLine();

                        if (system.DropStudentFromCourse(dropId, dropCourse))
                            Console.WriteLine("Course dropped successfully.");
                        else
                            Console.WriteLine("Drop failed.");
                        break;

                        case "5":
                        system.DisplayAllCourses();
                        break;

                        case "6":
                        Console.Write("Student ID: ");
                        string schedId = Console.ReadLine();

                        system.DisplayStudentSchedule(schedId);
                        break;

                        case "7":
                        system.DisplaySystemSummary();
                        break;

                        case "8":
                        exit = true;
                        Console.WriteLine("Exiting system...");
                        break;

                        default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;

                    }
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

