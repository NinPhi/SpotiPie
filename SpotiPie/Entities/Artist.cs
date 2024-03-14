namespace SpotiPie.Entities;

public class Artist
{
    public int Id { get; set; }
    public required string Pseudonym { get; set; }
    public int Followers { get; set; } = 0;
    public int MonthlyListeners { get; set; } = 0;
}