namespace SpotiPie.Contracts;

public record LyricsGetDto
{
    public required int Id { get; init; }
    public required int TrackId { get; init; }
    public required string Text { get; init; }
    public string? Translation { get; init; }
}
