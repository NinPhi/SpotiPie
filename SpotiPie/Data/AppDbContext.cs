using Microsoft.EntityFrameworkCore;
using SpotiPie.Models;
using SpotiPie.Entities;
using SpotiPie.Entity;
using SpotiPie.Text;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Track> Tracks => Set<Track>();
    public DbSet<User> Users => Set<User>();
    public DbSet<TextSong> Texts => Set<TextSong>();

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
