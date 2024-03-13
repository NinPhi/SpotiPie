using Microsoft.EntityFrameworkCore;
using SpotiPie.Models;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists => Set<Artist>();

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
}
