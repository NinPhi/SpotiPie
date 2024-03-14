using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities.Contracts;

public record TrackCreateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(10)]
    public string? Duration { get; init; }

    [Required]
    [StringLength(50)]
    public DateTime ReleaseDate { get; init; }
}
