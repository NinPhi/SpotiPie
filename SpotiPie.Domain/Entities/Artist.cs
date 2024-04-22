using SpotiPie.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Domain.Entities;

public class Artist : Entity
{
    [StringLength(200)]
    public required string Pseudonym { get; set; }

    public int Followers { get; set; } = 0;

    public int MonthlyListeners { get; set; } = 0;

    public List<Track> Tracks { get; set; } = new();

    public List<Album> Albums { get; set; } = new();
}