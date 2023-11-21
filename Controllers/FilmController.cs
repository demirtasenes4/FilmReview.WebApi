using Microsoft.AspNetCore.Mvc;
using FilmReview.WebApi.Context;
using FilmReview.WebApi.Models;
using Microsoft.VisualBasic;

namespace FilmReview.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly FilmReviewDbContext _context;
    public FilmController(FilmReviewDbContext context)
    {
        _context = context;
    }

    public record FilmDto(int Id, string Name, string Description, string Director, string Category, int Rating);

    [HttpPost]
    public IActionResult CreateFilm(FilmDto request)
    {
        Film film = new();
        film.Name = request.Name;
        film.Description = request.Description;
        film.Director = request.Director;
        film.Category = request.Category;
            
        _context.Add(film);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetFilm()
    {
        var response = _context.Films.FirstOrDefault();
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAllFilm()
    {
        return Ok(_context.Films.ToList());
    }
}