using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities.Contracts;

public record TrackCreateDto
{
    [Required]
    public int ArtistId { get; set; }

    public int? AlbumId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(100)]
    public string? Name { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(30)]
    public string? Duration { get; init; }

    [Required]
    [StringLength(50)]
    public DateTime ReleaseDate { get; init; }
}
