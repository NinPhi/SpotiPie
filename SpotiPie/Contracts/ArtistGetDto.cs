namespace SpotiPie.Contracts;

public record ArtistGetDto
{
    public required int Id { get; init; }
    public required string Pseudonym { get; init; }
    public required int Followers { get; init; }
    public required int MonthlyListeners { get; init; }
}
