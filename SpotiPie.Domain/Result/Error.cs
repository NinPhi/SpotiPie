namespace SpotiPie.Domain.Result;

public record Error(string Code, string? Message = null);
