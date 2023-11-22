using Microsoft.AspNetCore.Mvc;
using FilmReview.WebApi.Context;
using FilmReview.WebApi.Models;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;

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

    [HttpPost]
    public IActionResult CreateFilm(FilmDto request)
    {
        if (_context.Films.Where(f => f == request).FirstOrDefault() is not null)
        {
            return BadRequest(new { Message = "This Film is already exist!" });
        }

        Film film = new();
        film.Name = request.Name;
        film.Description = request.Description;
        film.Director = request.Director;
        film.Category = request.Category;
        film.ReleaseDate = request.ReleaseDate;
        film.Rate = request.Rate;

        _context.Add(film);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetFilm(string name)
    {
        var response = _context.Films.Where(f => f.Name == name).ToList();
        return Ok(response);
    }
    [HttpGet]
    public IActionResult GetAllFilm()
    {
        return Ok(_context.Films.ToList());
    }
}