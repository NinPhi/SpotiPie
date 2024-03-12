
using SpotiPie.Enum;

namespace SpotiPie.Entity;


public class Genre
{
    public int Id { get; set; }
    public GenresEnum Genres { get; set; }

    public string? Country { get; set; }
    public DateTime DateRelease { get; set; } = DateTime.Now;
    public int ArtistId { get; set; }

    public List<Artist>? Artists { get; set; } = new();

   
}


