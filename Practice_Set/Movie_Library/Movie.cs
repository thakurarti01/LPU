using System;
using System.Collections.Generic;

public interface IFilm
{
    string Title {get; set;}
    string Director {get; set;}
    int Year {get; set;}
}
public class Film : IFilm
{
    public string Title {get; set;}
    public string Director {get; set;}
    public int Year {get; set;}
}

public interface IFilmLibrary
{
    void AddFilm(Film film);
    void RemoveFilm(string title);
    void GetFilm();
    void SearchFilms(string query);
    int GetTotalFilmCount();
}
public class FilmLibrary : IFilmLibrary
{
    List <IFilm> _films = new List <IFilm> ()
    {
        new Film() {Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972},
        new Film() {Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994},
        new Film() {Title = "Schindler's List", Director = "Steven Spielberg", Year = 1993},
    };

    public void AddFilm(Film film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        IFilm filmToRemove = null;

        foreach(IFilm film in _films)
        {
            if(film.Title == title)
            {
                filmToRemove = film;
                break;
            }
        }

        if(filmToRemove != null)
        {
            _films.Remove(filmToRemove);
            Console.WriteLine("Film removed!");
        }
        else
        {
            Console.WriteLine("Film not found!");
        }
    }

    public void GetFilm()
    {
        foreach(IFilm film in _films)
        {
            Console.WriteLine($"{film.Title}, {film.Director}, {film.Year}");
        }
    }

    public void SearchFilms(string query)
    {
        bool found = false;
        foreach (IFilm film in _films)
        {
            if(film.Title.Contains(query) || film.Director.Contains(query))
            {
                Console.WriteLine($"Film Found: {film.Title}, {film.Director}, {film.Year}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Not Found!");
        }
    }

    public int GetTotalFilmCount()
    {
        int count = 0;

        foreach(IFilm film in _films)
        {
            count++;
        }
        return count;
    }
}