using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Application.Contracts;

public record GenreCreateDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; init; }
}
