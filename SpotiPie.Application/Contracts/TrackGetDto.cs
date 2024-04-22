namespace SpotiPie.Application.Contracts;

public record TrackGetDto
{
    public required int Id { get; init; }
    public required int ArtistId { get; init; }
    public int? AlbumId { get; init; }
    public required string Name { get; init; }
    public required string TrackDuration { get; init; }
    public required DateTime ReleaseDate { get; init; }
}
