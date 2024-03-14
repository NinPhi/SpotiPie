using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities;

public class Track
{
    public int Id { get; set; }

    public int ArtistId { get; set; }

    public int? AlbumId { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(30)]
    public required string Duration { get; set; }

    public required DateTime ReleaseDate { get; set; }

    public Artist? Artist { get; set; }

    public Album? Album { get; set; }

    public List<Genre> Genres { get; set; } = new();
}
