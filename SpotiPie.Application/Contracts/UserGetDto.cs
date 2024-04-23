namespace SpotiPie.Application.Contracts;

public record UserGetDto
{
    public required int Id { get; init; }
    public required string Login { get; init; }
    public required string Role { get; init; }
}
