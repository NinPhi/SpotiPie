namespace SpotiPie.Application.Contracts;

public record GenreGetDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}
