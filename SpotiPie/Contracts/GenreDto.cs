using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Contracts;

public record GenreDto
{
    [Required]
    [StringLength(100, ErrorMessage = "{0} must less than {1} chars long.")]
    public string? Name { get; set; }
}
