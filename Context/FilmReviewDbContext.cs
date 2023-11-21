using Microsoft.EntityFrameworkCore;
using FilmReview.WebApi.Models;

namespace FilmReview.WebApi.Context;

public class FilmReviewDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=QUADESH;Initial Catalog=FilmRevDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<FilmCategory> FilmCategories { get; set; }
}
