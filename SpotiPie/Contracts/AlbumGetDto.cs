namespace SpotiPie.Contracts;

public record AlbumGetDto
{
    public required int Id { get; init; }
    public required int ArtistId{ get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required DateTime ReleaseYear { get; init; }
}
