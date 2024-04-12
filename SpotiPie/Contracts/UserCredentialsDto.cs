using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Contracts;

public record UserCredentialsDto
{
    [Required(AllowEmptyStrings = false)]
    [StringLength(200, MinimumLength = 4)]
    public string? Login { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(200, MinimumLength = 4)]
    public string? Password { get; init; }
}
