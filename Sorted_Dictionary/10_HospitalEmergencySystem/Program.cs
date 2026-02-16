using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("\n1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Remove");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var entity in service.GetAll())
                            {
                                Console.WriteLine(entity.Id);
                            }
                            break;

                        case 2:
                            Console.Write("Enter Key (priority): ");
                            int key = int.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Enter Patient Id: ");
                            string id = Console.ReadLine() ?? "";

                            Patient patient = new Patient { Id = id };
                            service.AddEntity(key, patient);

                            Console.WriteLine("Added successfully.");
                            break;

                        case 3:
                            Console.Write("Enter Key to update: ");
                            int updateKey = int.Parse(Console.ReadLine() ?? "0");
                            service.UpdateEntity(updateKey);
                            break;

                        case 4:
                            Console.Write("Enter Key to remove: ");
                            int removeKey = int.Parse(Console.ReadLine() ?? "0");
                            service.RemoveEntity(removeKey);
                            Console.WriteLine("Removed successfully.");
                            break;

                        case 5:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
