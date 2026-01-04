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
    void GetTotalFilmCount();
}
public class FilmLibrary : IFilmLibrary
{
    List <IFilm> _films = new List <IFilm> ()
    {
        new IFilm() {Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972},
    };

    public void AddFilm(Film film)
    {
        // IFilm obj = new IFilm();

    }

    public void RemoveFilm(string title)
    {
        
    }

    public void GetFilm()
    {
        
    }

    public void SearchFilms(string query)
    {
        
    }

    public void GetTotalFilmCount()
    {
        
    }
}