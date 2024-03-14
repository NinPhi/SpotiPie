using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Contracts;

public record AlbumCreateDto
{
    [Required]
    public int ArtistId{ get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(200)]
    public string? Name { get; init; }

    [StringLength(2000)]
    public string? Description { get; init; }

    [Required]
    public DateTime ReleaseYear { get; init; }
}
