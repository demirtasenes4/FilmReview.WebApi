using Azure.Core;

namespace FilmReview.WebApi.Models;

public class Film
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Category { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int Rate { get; set; }
    public static bool operator ==(Film film, FilmDto filmDto) =>
        film.Name == filmDto.Name && film.Director == filmDto.Director && film.ReleaseDate == filmDto.ReleaseDate;
    public static bool operator !=(Film film, FilmDto filmDto) => 
        !(film == filmDto);
}

public class FilmDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Category { get; set; }
    public int Rate { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
