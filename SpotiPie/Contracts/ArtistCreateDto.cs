using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Contracts;

public record ArtistCreateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(200)]
    public string? Pseudonym { get; init; }
}
