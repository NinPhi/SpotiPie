using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Contracts;

public record LyricsCreateDto
{
    [Required]
    public int TrackId { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(2000)]
    public string? Text { get; init; }

    [StringLength(2000)]
    public string? Translation { get; init; }
}
