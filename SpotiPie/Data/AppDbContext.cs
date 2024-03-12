using Microsoft.EntityFrameworkCore;
using SpotiPie.Entity;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().ToTable("Genres");
    }
}

