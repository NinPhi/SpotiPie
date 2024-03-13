namespace SpotiPie.Entities;

public class Album
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required DateTime ReleaseYear { get; set; }
    public required int ArtistId { get; set; }
}
