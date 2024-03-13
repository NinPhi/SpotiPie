using Microsoft.EntityFrameworkCore;
using SpotiPie.Entities;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<User> Users => Set<User>();
    public DbSet<TextSong> Texts => Set<TextSong>();
    public DbSet<Genre> Genres => Set<Genre>();

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}

