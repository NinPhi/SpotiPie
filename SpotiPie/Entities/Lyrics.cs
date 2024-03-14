using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities;

public class Lyrics
{
    public int Id { get; set; }

    public required int TrackId { get; set; }

    [StringLength(4000)]
    public required string Text { get; set; }

    [StringLength(4000)]
    public string? Translation { get; set; }

    public Track? Track { get; set; }
}
