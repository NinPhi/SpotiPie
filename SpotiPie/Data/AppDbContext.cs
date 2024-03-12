using Microsoft.EntityFrameworkCore;
using SpotiPie.Text;

namespace SpotiPie.Data;

public class AppDbContext : DbContext
{
    public DbSet<TextSong> Texts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }


}
