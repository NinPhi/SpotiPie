using System.Security.Principal;

namespace SpotiPie.Entity;

public class Artist
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int GenreId { get; set; }
    public List<Genre> Genres { get; set; } = new();


}
