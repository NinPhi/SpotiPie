using SpotiPie.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Domain.Entities;

public class Lyrics : Entity
{
    public required int TrackId { get; set; }

    [StringLength(4000)]
    public required string Text { get; set; }

    [StringLength(4000)]
    public string? Translation { get; set; }

    public Track? Track { get; set; }
}
