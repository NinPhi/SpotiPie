namespace SpotiPie.Entities.Contracts;

public record TrackGetDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Duration { get; init; }
    public required DateTime ReleaseDate { get; init; }
}
