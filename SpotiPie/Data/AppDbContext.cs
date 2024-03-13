using Microsoft.EntityFrameworkCore;
using SpotiPie.Models;
using SpotiPie.Entities;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
}
