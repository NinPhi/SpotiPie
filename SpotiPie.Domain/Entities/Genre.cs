using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Domain.Entities;

public class Genre : Entity
{
    [StringLength(100)]
    public required string Name { get; set; }

    public List<Track> Tracks { get; set; } = new();
}