using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities;

public class Genre
{
    public int Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    public List<Track> Tracks { get; set; } = new();
}