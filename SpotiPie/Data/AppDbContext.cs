using Microsoft.EntityFrameworkCore;
using SpotiPie.Entity;
namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
    public DbSet<User> Users { get; set; }

}
