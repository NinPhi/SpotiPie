namespace SpotiPie.Entities.Contracts;

public class TrackDto
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Duration { get; init; }

    public DateTime ReleaseDate { get; init; }
}
