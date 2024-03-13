namespace SpotiPie.Entities;

public class Track
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Duration { get; set; }

    public required DateTime ReleaseDate { get; set; }
}
