namespace FilmReview.WebApi.Models;

public class Film
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Category { get; set; }
    public int Rate { get; set; }
}
