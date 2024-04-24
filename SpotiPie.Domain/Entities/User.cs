using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Domain.Entities;

public class User : Entity
{
    public int Id { get; set; }

    [StringLength(200)]
    public required string Login { get; set; }

    [StringLength(200)]
    public required string PasswordHash { get; set; }

    [StringLength(300)]
    public required string Role { get; set; }
}
