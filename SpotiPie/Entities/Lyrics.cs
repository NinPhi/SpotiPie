namespace SpotiPie.Entities;

public class Lyrics
{
    public int Id { get; set; }

    public required int TrackId { get; set; }

    public required string Text { get; set; }

    public string? Translation { get; set; }
}
