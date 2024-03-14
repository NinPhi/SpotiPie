using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities;

public class Album
{
    public int Id { get; set; }

    public required int ArtistId { get; set; }

    [StringLength(200)]
    public required string Name { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public required DateTime ReleaseYear { get; set; }

    public Artist? Artist { get; set; }

    public List<Track> Tracks { get; set; } = new();
}
