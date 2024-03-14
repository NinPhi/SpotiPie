using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities.Contracts;

public record TrackUpdateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string? Duration { get; init; }

    [Required]
    public DateTime ReleaseDate { get; init; }
}
