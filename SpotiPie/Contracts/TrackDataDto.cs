namespace SpotiPie.Contracts;

public record TrackDataDto
{
    public required int TrackId { get; init; }
    public required string FileName { get; init; }
    public required string MediaType { get; init; }
    public required byte[] Data { get; init; }
}
