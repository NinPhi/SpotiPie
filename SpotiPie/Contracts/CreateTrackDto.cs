using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities.Contracts;

public class CreateTrackDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(10)]
    public string Duration { get; init; }

    [Required]
    [MaxLength(50)]
    public string ReleaseDate { get; init; }
}
