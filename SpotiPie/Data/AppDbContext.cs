using Microsoft.EntityFrameworkCore;
using SpotiPie.Entities;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<Album> Albums { get; set; }

}
