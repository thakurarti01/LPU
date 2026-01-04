// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        FilmLibrary obj = new FilmLibrary();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("========== Film Menu ===========");

            Console.WriteLine("1. Add a film");
            Console.WriteLine("2. Remove a film");
            Console.WriteLine("3. Display all films");
            Console.WriteLine("4. Search films");
            Console.WriteLine("5. Get total film count");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                {

                    Console.Write("Enter film title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter director name: ");
                    string director = Console.ReadLine();

                    Console.Write("Enter year of release: ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    Film newFilm = new Film()
                    {
                        Title = title,
                        Director = director,
                        Year = year
                    };

                    obj.AddFilm(newFilm);
                    Console.WriteLine("Film added successfully!");
                    break;
                }
                case 2:
                {
                    Console.Write("Enter the title of the film to remove: ");
                    string title = Console.ReadLine();
                    obj.RemoveFilm(title);
                    break;
                }
                case 3:
                {
                    obj.GetFilm();
                    break;
                }
                case 4:
                {
                    Console.Write("Enter film title or director to search: ");
                    string query = Console.ReadLine();
                    obj.SearchFilms(query);
                    break;
                }  
                case 5:
                {
                    int total = obj.GetTotalFilmCount();
                    Console.Write($"Total films: {total}");
                    break;
                }
                case 6:
                {
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid option!");
                    break;
                }
            }
        }
    }
}